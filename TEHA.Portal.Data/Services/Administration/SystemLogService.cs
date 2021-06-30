// <copyright file="SystemLogService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Services.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using BITLogix.Core.Couchbase;
    using TEHA.Portal.Data.Models.Administration;

    /// <summary>
    /// System Log Data store
    /// </summary>
    public class SystemLogService
    {
        private readonly IDbClient<SystemLog> dbClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemLogService"/> class.
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public SystemLogService(IConfiguration configuration)
        {
            this.dbClient = DbClientFactory.Default.Create<SystemLog>(configuration);
        }

        /// <summary>
        /// Gets list of all System Log
        /// </summary>
        /// <returns>List<TEHA.Portal.Data.Models.Admin.EmailTemplate></returns>
        public List<SystemLog> GetAll()
        {
            return this.dbClient.GetAll().ToList();
        }

        /// <summary>
        /// Gets list System Log
        /// </summary>
        /// <param name="predicate">Expression</param>
        /// <returns>List<TEHA.Portal.Data.Models.Admin.EmailTemplate></returns>
        public List<SystemLog> Where(Expression<Func<SystemLog, bool>> predicate)
        {
            return this.dbClient.Where(predicate).ToList();
        }

        /// <summary>
        /// Insert/Save System log entry
        /// </summary>
        /// <param name="systemLog">SystemLog</param>
        public void Insert(SystemLog systemLog)
        {
            this.dbClient.Insert(systemLog);
        }
    }
}
