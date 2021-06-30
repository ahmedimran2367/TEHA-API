// <copyright file="DbClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BITLogix.Core.Couchbase
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using global::Couchbase.Lite;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// DB Client Base
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    public class DbClient<TEntity> : IDbClient<TEntity>, IAsyncDisposable, IDisposable
        where TEntity : IEntityBase
    {
        private readonly string documentType;
        private readonly IConfiguration configuration;
        private readonly string directory = Directory.GetCurrentDirectory();
        private Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbClient{TEntity}"/> class.
        /// Constructor
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        internal DbClient(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.database = new Database(configuration.DatabaseName, new DatabaseConfiguration()
            {
                Directory = this.directory,
            });

            this.database.AddChangeListener(this.OnDataBaseChanged);

            DocumentTypeAttribute collAttribute = typeof(TEntity).GetCustomAttribute<DocumentTypeAttribute>();
            if (collAttribute != null)
            {
                this.documentType = collAttribute.DocumentType;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DbClient{TEntity}"/> class.
        /// </summary>
        ~DbClient()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Deletes an element from the document
        /// </summary>
        /// <param name="entity">Object to be deleted</param>
        public void Delete(TEntity entity)
        {
            using (var mutableDocument = this.database.GetDocument(this.documentType).ToMutable())
            {
                List<TEntity> items = JsonConvert.DeserializeObject<List<TEntity>>(
                    JsonConvert.SerializeObject(mutableDocument.GetArray(this.configuration.ItemsArrayFieldName)));

                items.RemoveAt(items.FindIndex(p => p.Id == entity.Id));
                mutableDocument.SetArray(this.configuration.ItemsArrayFieldName, new MutableArrayObject(JsonConvert.DeserializeObject<List<dynamic>>(
                    JsonConvert.SerializeObject(items))));
                this.database.Save(mutableDocument);
            }
        }

        /// <summary>
        /// Inserts an element into the document
        /// </summary>
        /// <param name="entity">Object to be inserted</param>
        public void Insert(TEntity entity)
        {
            using (var mutableDocument = this.database.GetDocument(this.documentType).ToMutable())
            {
                List<TEntity> items = JsonConvert.DeserializeObject<List<TEntity>>(
                    JsonConvert.SerializeObject(mutableDocument.GetArray(this.configuration.ItemsArrayFieldName)));

                entity.Id = items.Count;
                items.Add(entity);
                mutableDocument.SetArray(this.configuration.ItemsArrayFieldName, new MutableArrayObject(JsonConvert.DeserializeObject<List<dynamic>>(
                    JsonConvert.SerializeObject(items))));
                this.database.Save(mutableDocument);
            }
        }

        /// <summary>
        /// Updates an element in the document
        /// </summary>
        /// <param name="entity">Object to be updated</param>
        public void Update(TEntity entity)
        {
            using (var mutableDocument = this.database.GetDocument(this.documentType).ToMutable())
            {
                List<TEntity> items = JsonConvert.DeserializeObject<List<TEntity>>(
                    JsonConvert.SerializeObject(mutableDocument.GetArray(this.configuration.ItemsArrayFieldName)));
                items[items.FindIndex(p => p.Id == entity.Id)] = entity;

                mutableDocument.SetArray(this.configuration.ItemsArrayFieldName, new MutableArrayObject(JsonConvert.DeserializeObject<List<dynamic>>(
                    JsonConvert.SerializeObject(items))));
                this.database.Save(mutableDocument);
            }
        }

        /// <summary>
        /// Gets All records
        /// </summary>
        /// <returns>List of <see cref="TEntity"/></returns>
        public IEnumerable<TEntity> GetAll()
        {
            var items = this.database.GetDocument(this.documentType).GetArray(this.configuration.ItemsArrayFieldName);

            string list = JsonConvert.SerializeObject(items);
            return JsonConvert.DeserializeObject<List<TEntity>>(list);
        }

        /// <summary>
        /// Where query on bucket
        /// </summary>
        /// <param name="predicate">query</param>
        /// <returns>List of <see cref="TEntity"/></returns>
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var items = this.database.GetDocument(this.documentType).GetArray(this.configuration.ItemsArrayFieldName);

            string list = JsonConvert.SerializeObject(items);
            return JsonConvert.DeserializeObject<List<TEntity>>(list).AsQueryable().Where(predicate);
        }

        /// <summary>
        /// Returns first or default object matching the query
        /// </summary>
        /// <param name="predicate">query</param>
        /// <returns>TEntity object</returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            var items = this.database.GetDocument(this.documentType).GetArray(this.configuration.ItemsArrayFieldName);

            string list = JsonConvert.SerializeObject(items);
            return JsonConvert.DeserializeObject<List<TEntity>>(list).AsQueryable().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Returns single or default object matching the query
        /// </summary>
        /// <param name="predicate">query</param>
        /// <returns>TEntity object</returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            var items = this.database.GetDocument(this.documentType).GetArray(this.configuration.ItemsArrayFieldName);

            string list = JsonConvert.SerializeObject(items);
            return JsonConvert.DeserializeObject<List<TEntity>>(list).AsQueryable().SingleOrDefault(predicate);
        }

        /// <summary>
        /// Dispose resources
        /// </summary>
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            await this.DisposeAsyncCore();

            this.Dispose(disposing: false);
        }

        /// <summary>
        /// Synchronous cleanup
        /// </summary>
        /// <param name="disposing">indicator to disposing or not</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.database != null)
            {
                this.database.Dispose();
            }
            else if (this.database != null)
            {
                this.database = null;
            }
        }

        /// <summary>
        /// Asynchronous cleanup
        /// </summary>
        /// <returns>ValueTask</returns>
        protected virtual ValueTask DisposeAsyncCore()
        {
            if (this.database != null)
            {
                return new ValueTask(Task.Run(this.database.Dispose));
            }

            this.database = null;
            return new ValueTask(Task.CompletedTask);
        }

        /// <summary>
        /// Database Change handler
        /// </summary>
        /// <param name="sender"> Sender object</param>
        /// <param name="e"> Arguments of event</param>
        private void OnDataBaseChanged(object sender, DatabaseChangedEventArgs e)
        {
            try
            {
                var document = this.database.GetDocument(e.DocumentIDs.FirstOrDefault());

                JObject jObject = JObject.Parse(File.ReadAllText($"{this.directory}/{this.configuration.DocumentsFilename}", Encoding.UTF8));
                jObject[document.Id] = JObject.Parse(JsonConvert.SerializeObject(document));

                using (StreamWriter file = File.CreateText($"{this.directory}/{this.configuration.DocumentsFilename}"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, jObject);

                    file.Flush();
                }
            }
            catch (Exception exc)
            {
                throw new UnableToChangeDatabaseException("Unable to change database", exc) { Name = e.Database?.Name ?? "<Null>", DocumentIDs = e.DocumentIDs };
            }
        }
    }
}
