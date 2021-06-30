// <copyright file="IDbClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BITLogix.Core.Couchbase
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Database client
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IDbClient<TEntity>
        where TEntity : IEntityBase
    {
        /// <summary>
        /// Deletes an element from the document
        /// </summary>
        /// <param name="entity">Object to be deleted</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Returns first or default object matching the query
        /// </summary>
        /// <param name="predicate">query</param>
        /// <returns>TEntity object</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Gets All records
        /// </summary>
        /// <returns>List of <see cref="TEntity"/></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Inserts an element into the document
        /// </summary>
        /// <param name="entity">Object to be inserted</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Returns single or default object matching the query
        /// </summary>
        /// <param name="predicate">query</param>
        /// <returns>TEntity object</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Updates an element in the document
        /// </summary>
        /// <param name="entity">Object to be updated</param>
        void Update(TEntity entity);

        /// <summary>
        /// Where query on bucket
        /// </summary>
        /// <param name="predicate">query</param>
        /// <returns>List of <see cref="TEntity"/></returns>
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}