// <copyright file="Configuration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API
{
    using System;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Implements Project Configuration
    /// </summary>
    public class Configuration : BITLogix.Core.Couchbase.IConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="configurationSection">IConfigurationSection</param>
        public Configuration(IConfigurationSection configurationSection)
        {
            this.DatabaseName = configurationSection.GetSection("ConnectionConfiguration").GetSection("CouchbaseLite")["DatabaseName"];
            this.DocumentsFilename = configurationSection.GetSection("ConnectionConfiguration").GetSection("CouchbaseLite")["DocumentsFilename"];
            this.UpdateDocumentsInd = configurationSection.GetSection("ConnectionConfiguration").GetSection("CouchbaseLite").GetSection("UpdateDocumentsInd").Get<bool>();
            this.Secret = configurationSection.GetValue<string>("Secret");
        }

        /// <summary>
        /// Gets or sets DatabaseName
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets DocumentsFile
        /// </summary>
        public string DocumentsFilename { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether UpdateDocumentsInd is true or false
        /// </summary>
        public bool UpdateDocumentsInd { get; set; }

        /// <summary>
        /// Gets or sets JWT Secret Key
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="name">name of configuration</param>
        /// <returns>String</returns>
        public string Get(string name)
        {
            var pinfo = this.GetType().GetProperty(name);
            if (pinfo != null)
            {
                return $"{pinfo.GetValue(this)}";
            }
            else
            {
                throw new ArgumentException("Invalid property Name", nameof(name));
            }
        }
    }
}
