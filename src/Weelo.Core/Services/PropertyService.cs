using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weelo.Core.DTOs;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;
using Weelo.Core.Wrappers;

namespace Weelo.Core.Services
{
    /// <summary>
    /// Property Service
    /// </summary>
    /// <seealso cref="IPropertyService" />
    public class PropertyService : IPropertyService
    {

        #region Propiedades

        /// <summary>
        /// The repository service
        /// </summary>
        private readonly IPropertyRepository propertyRepository;

        private readonly IOwnerRepository ownerRepository;

        private readonly IRepository<PropertyImage> imageRepository;

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyService"/> class.
        /// </summary>
        /// <param name="propertyService">The property repository.</param>        
        public PropertyService(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository, IRepository<PropertyImage> imageRepository)
        {
            this.propertyRepository = propertyRepository;
            this.ownerRepository = ownerRepository;
            this.imageRepository = imageRepository;
        }

        /// <summary>
        /// Creates a new property
        /// </summary>
        /// <param name="Property">The property.</param>
        /// <returns>a property</returns>
        public async Task<Response<CreatePropertyResponse>> InsertAsync(CreatePropertyRequest request)
        {
            Property entity = request.CreateToBase();
            var result = await this.propertyRepository.InsertAsync(entity);
            return new Response<CreatePropertyResponse>(result.CreateToModel());
        }

        /// <summary>
        /// Updates the specified property.
        /// </summary>
        /// <param name="Property">The property.</param>
        /// <returns>the task</returns>
        public async Task<Response<string>> UpdateAsync(UpdatePropertyRequest request)
        {
            var propertyEntity = this.propertyRepository.TableNoTracking.Where(x => x.IdProperty == request.IdProperty).FirstOrDefault();
            if (propertyEntity == null)
            {
                return new Response<string>("Property not found");
            }

            var owner = this.ownerRepository.TableNoTracking.Where(x => x.IdOwner == request.IdOwner);
            if (owner.Any() == false)
            {
                return new Response<string>("Owner not found");
            }

            propertyEntity.Name = string.IsNullOrEmpty(request.Name) ? propertyEntity.Name : request.Name.Trim();
            propertyEntity.Address = string.IsNullOrEmpty(request.Address) ? propertyEntity.Address : request.Address.Trim();
            propertyEntity.Price = !request.Price.HasValue ? propertyEntity.Price : request.Price;
            propertyEntity.CodeInternal = string.IsNullOrEmpty(request.CodeInternal) ? propertyEntity.CodeInternal : request.CodeInternal.Trim();
            propertyEntity.Year = !request.Year.HasValue ? propertyEntity.Year : request.Year.Value;
            propertyEntity.IdOwner = !request.IdOwner.HasValue ? propertyEntity.IdOwner : request.IdOwner.Value;

            await this.propertyRepository.UpdateAsync(propertyEntity);
            return new Response<string>("Property updated");

        }

        public async Task<Response<PropertyResponse>> UpdatePriceAsync(UpdatePropertyPriceRequest request)
        {
            await this.propertyRepository.UpdatePrice(request.IdProperty, request.Price);
            var result = this.propertyRepository.Table.FirstOrDefault(x=>x.IdProperty == request.IdProperty);
            return new Response<PropertyResponse>(result.ToModel(),"Price updated");
        }

        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="propertyId">The identifier.</param>
        /// <returns>the task</returns>
        public Task Delete(int propertyId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets all property.
        /// </summary>
        /// <returns>the list properties</returns>
        public async Task<IList<PropertyResponse>> GetAll()
        {
            var properties = await propertyRepository.GetAll();

            return properties.Where(x => x.Active && !x.Deleted).ToList().ToModels();
        }



        /// <summary>
        /// Gets all properties.
        /// </summary>
        /// <returns>the list properties</returns>
        public Response<IList<PropertyResponse>> GetAll
        (
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
            var properties = this.propertyRepository.GetAll(
                owner: owner,
                address: address,
                minPrice: minPrice,
                maxPrice: maxPrice,
                pageIndex: pageIndex,
                pageSize: pageSize).ToList(); ;

            return new Response<IList<PropertyResponse>>(properties.ToModels());
        }

        public async Task<Response<CreatePropertyImageResponse>> InsertImageAsync(CreatePropertyImageRequest request)
        {

            PropertyImage entity = request.CreateToBase();
            
            var propertyEntity = this.propertyRepository.TableNoTracking.Where(x => x.IdProperty == request.IdProperty);
            if (propertyEntity == null)
            {
                return new Response<CreatePropertyImageResponse>("Property not found");
            }

            var result = await this.imageRepository.InsertAsync(entity);

            return new Response<CreatePropertyImageResponse>(result.CreateToModel());

        }

    }
}
