using System.Collections.Generic;
using System.Threading.Tasks;
using Weelo.Core.DTOs;
using Weelo.Core.Wrappers;

namespace Weelo.Core.Interfaces
{
    public interface IPropertyService
    {
        /// <summary>
        /// Creates a new property
        /// </summary>
        /// <param name="Property">The property.</param>
        /// <returns>a property</returns>
        Task<Response<CreatePropertyResponse>> InsertAsync(CreatePropertyRequest request);

        /// <summary>
        /// Updates the specified property.
        /// </summary>
        /// <param name="Property">The property.</param>
        /// <returns>the task</returns>
        Task<Response<string>> UpdateAsync(UpdatePropertyRequest request);


        Task<Response<PropertyResponse>> UpdatePriceAsync(UpdatePropertyPriceRequest request);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="propertyId">The identifier.</param>
        /// <returns>the task</returns>
        Task Delete(int propertyId);

        /// <summary>
        /// Gets all property.
        /// </summary>
        /// <returns>the list ownners</returns>
        Task<IList<PropertyResponse>> GetAll();

        /// <summary>
        /// Gets all properties.
        /// </summary>
        /// <returns>the list properties</returns>
        Response<IList<PropertyResponse>> GetAll
        (
            string owner,
            string address,
            decimal? minPrice,
            decimal? maxPrice,
            int pageSize = 10,
            int pageIndex = 0,
            bool status = true,
            bool deleted = false
        );
        

        Task<Response<CreatePropertyImageResponse>> InsertImageAsync(CreatePropertyImageRequest request);


    }
}
