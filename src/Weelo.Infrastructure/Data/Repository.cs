using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Weelo.Core.Interfaces;
using System.Collections.Generic;

namespace Weelo.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// The context
        /// </summary>
        //private readonly IDbContext context;
        private protected readonly WeeloContext context;

        /// <summary>
        /// The entities
        /// </summary>
        private DbSet<TEntity> entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(WeeloContext context)
        {
            this.context = context;
            ////this.context2.ChangeTracker2();
        }

        /// <summary>
        /// Gets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (this.entities == null)
                {
                    this.entities = this.context.Set<TEntity>();
                }

                return this.entities;
            }
        }

        /// <summary>
        /// Gets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        public IQueryable<TEntity> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// Gets the table no tracking.
        /// </summary>
        /// <value>
        /// The table no tracking.
        /// </value>
        public IQueryable<TEntity> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }



        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the task</returns>
        /// <exception cref="System.ArgumentNullException">the entity</exception>
        /// 
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await this.Entities.AddAsync(entity);
            this.context.SaveChanges();

            return entity;            
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the task</returns>
        /// <exception cref="System.ArgumentNullException">the entity</exception>
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            this.Entities.Update(entity).State = EntityState.Modified;
            //this.Entities.Attach(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }


        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.ArgumentNullException">the entity</exception>
        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.Entities.Remove(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// the entity
        /// </returns>
        public TEntity GetById(Int64 id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// Gets All.
        /// </summary>
        /// <returns>the all owner</returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.Entities.ToListAsync();
        }

    }
}
