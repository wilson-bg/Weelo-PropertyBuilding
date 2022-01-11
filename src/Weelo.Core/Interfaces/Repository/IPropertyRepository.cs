using System;
using System.Threading.Tasks;
using Weelo.Core.Entities;

namespace Weelo.Core.Interfaces
{
    public interface IPropertyRepository : IRepository<Property>
    {

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the task</returns>
        /// <exception cref="System.ArgumentNullException">the entity</exception>
        Task UpdatePrice(Int64 IdProperty, decimal price);

        /// <summary>
        /// Gets All.
        /// </summary>
        /// <returns>the all owner</returns>
        IPagedList<Property> GetAll(
            string owner,
            string address,
            decimal? minPrice,
            decimal? maxPrice,
            int pageSize = 10,
            int pageIndex = 0,
            bool status = true,
            bool deleted = false
        );

    }
}
