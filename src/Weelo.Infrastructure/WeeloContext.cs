using Microsoft.EntityFrameworkCore;
using Weelo.Core.Entities;

namespace Weelo.Infrastructure
{
    /// <summary>
    /// Database Context
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class WeeloContext : DbContext//, IDbContext
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="WeeloContext"/> class.
        /// </summary>
        public WeeloContext(DbContextOptions<WeeloContext> options) 
            : base(options)
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //Database IDbContext.Database => throw new System.NotImplementedException();

        //Task<int> IDbContext.SaveChangesAsync()
        //{
        //    throw new System.NotImplementedException();
        //}

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public DbSet<Owner> Owner { get; set; }

        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        /// <value>
        /// The property.
        /// </value>
        public DbSet<Property> Properties { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration} (new OwnerMap());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeeloContext).Assembly);

        }


    }
}
