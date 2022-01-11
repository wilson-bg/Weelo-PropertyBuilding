using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weelo.Core.Interfaces
{
    /// <summary>
    /// Interface for repository tables
    /// </summary>
    /// <typeparam name="TEntity">the entity</typeparam>
    public interface IRepository<TEntity> where TEntity : IEntity
    {

        /// <summary>
        /// Gets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets the table no tracking.
        /// </summary>
        /// <value>
        /// The table no tracking.
        /// </value>
        IQueryable<TEntity> TableNoTracking { get; }


        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the task</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the task</returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the entity</returns>
        TEntity GetById(Int64 id);

        /// <summary>
        /// Gets All.
        /// </summary>
        /// <returns>the all owner</returns>
        Task<IEnumerable<TEntity>> GetAll();

    }
}
