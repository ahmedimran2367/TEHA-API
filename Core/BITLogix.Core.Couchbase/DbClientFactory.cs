// <copyright file="DbClientFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BITLogix.Core.Couchbase
{
    /// <summary>
    /// DbClient Factory
    /// </summary>
    public class DbClientFactory
    {
        private static readonly object LockObject = new object();
        private static DbClientFactory instance;

        /// <summary>
        /// Gets default instance
        /// </summary>
        public static DbClientFactory Default
        {
            get
            {
                lock (LockObject)
                {
                    if (instance == null)
                    {
                        instance = new DbClientFactory();
                    }

                    return instance;
                }
            }
        }

        /// <summary>
        /// Create DBClient instance against configuration
        /// </summary>
        /// <typeparam name="TEntity">Entity base type</typeparam>
        /// <param name="configuration">Configuration to create dbclient instance</param>
        /// <returns>Returns db client instance</returns>
        public IDbClient<TEntity> Create<TEntity>(IConfiguration configuration)
            where TEntity : IEntityBase
        {
            return new DbClient<TEntity>(configuration);
        }
    }
}
