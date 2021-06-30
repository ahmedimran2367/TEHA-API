// <copyright file="DatabaseScripts.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using BITLogix.Core.Couchbase;
    using Couchbase.Lite;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Database Scripts to be run at startup
    /// </summary>
    public class DatabaseScripts
    {
        private readonly string directory = Directory.GetCurrentDirectory();
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseScripts"/> class.
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public DatabaseScripts(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Database Initialize method which creates (if not exists) database and add documents
        /// </summary>
        public void Initialize()
        {
            if (!Database.Exists(this.configuration.DatabaseName, this.directory))
            {
                this.CreateDatabase();
            }

            if (this.configuration.UpdateDocumentsInd)
            {
                this.GenerateDocuments();
            }
        }

        /// <summary>
        /// Creates database in current directory
        /// </summary>
        private void CreateDatabase()
        {
            using Database database = new Database(this.configuration.DatabaseName, new DatabaseConfiguration()
            {
                Directory = this.directory,
            });

            database.Close();
        }

        /// <summary>
        /// Generates documents in database from json file
        /// </summary>
        private void GenerateDocuments()
        {
            using (Database database = new Database(this.configuration.DatabaseName, new DatabaseConfiguration()
            {
                Directory = this.directory,
            }))
            {
                JObject jObject = JObject.Parse(File.ReadAllText($"{this.directory}/{this.configuration.DocumentsFilename}", Encoding.UTF8));

                List<JToken> documents = jObject.Children().ToList();

                foreach (var document in documents)
                {
                    var documentType = document.Children().FirstOrDefault().SelectToken("type").ToString();
                    ArrayObject items = new MutableArrayObject(JsonConvert.DeserializeObject<List<dynamic>>(document.Children().FirstOrDefault().SelectToken("items").ToString()));
                    using (var mutableDoc = new MutableDocument(documentType))
                    {
                        mutableDoc.SetString("type", documentType)
                            .SetArray("items", items);

                        // Save it to the database
                        database.Save(mutableDoc);
                    }
                }
            }
        }
    }
}
