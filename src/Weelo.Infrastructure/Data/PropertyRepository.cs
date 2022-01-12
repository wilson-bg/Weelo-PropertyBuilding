using System;
using System.Linq;
using System.Threading.Tasks;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Weelo.Infrastructure.Data
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(WeeloContext context) : base(context)
        {
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <returns>the task</returns>
        /// <exception cref="System.ArgumentNullException">the entity</exception>
        public async Task UpdatePrice(Int64 idProperty, decimal price)
        {           
            if (idProperty < 1)
            {
                throw new ArgumentNullException("IdProperty");
            }
            var entityUpdated = this.Entities.Single(x => x.IdProperty == idProperty);
            entityUpdated.Price = price;           
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets All.
        /// </summary>
        /// <returns>the all owner</returns>
        public IPagedList<Property> GetAll(
            string owner,
            string address,
            decimal? minPrice,
            decimal? maxPrice,
            int pageSize = 10,
            int pageIndex = 0,
            bool status = true,
            bool deleted = false
        )
        {
            var query = this.TableNoTracking.Where(x => x.Active == status && x.Deleted == deleted);

            if (!string.IsNullOrEmpty(owner))
            {
                query = query.Include(x => x.Owner).Where(x => x.Owner.Name.ToLower().Contains(owner.Trim().ToLower()));
            }
            else
            {
                query = query.Include(x => x.Owner);
            }

            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(x => x.Address.ToLower().Contains(address.Trim().ToLower()));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(x=>x.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= maxPrice.Value);
            }

            query = query.OrderByDescending(x=> x.IdProperty);

            return new PagedList<Property>(query, pageIndex, pageSize); ;
        }

    }
}
