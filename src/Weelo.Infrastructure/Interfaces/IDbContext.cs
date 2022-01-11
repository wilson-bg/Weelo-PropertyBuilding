//using System;
////using System.Data.Entity;
//using System.Threading.Tasks;
////using System.Data.Entity.Infrastructure;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Microsoft.EntityFrameworkCore.Storage;

//namespace Weelo.Infrastructure.Interfaces
//{
//    public interface IDbContext : IDisposable
//    {
//        ///// <summary>
//        ///// Gets the change tracker.
//        ///// </summary>
//        ///// <value>
//        ///// The change tracker.
//        ///// </value>
//        //ChangeTracker ChangeTracker2 { get; }

//        ///// <summary>
//        ///// Gets the database.
//        ///// </summary>
//        ///// <value>
//        ///// The database.
//        ///// </value>
//        //Database Database { get; }

//        /// <summary>
//        /// Sets this instance.
//        /// </summary>
//        /// <typeparam name="TEntity">The type of the entity.</typeparam>
//        /// <returns>the table</returns>
//        DbSet<TEntity> Set<TEntity>() where TEntity : class;

//        /// <summary>
//        /// Saves the changes.
//        /// </summary>
//        /// <returns>modified records</returns>
//        int SaveChanges();

//        /// <summary>
//        /// Saves the changes asynchronous.
//        /// </summary>
//        /// <returns>the task</returns>
//        Task<int> SaveChangesAsync();

//    }
//}
