using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Weelo.Core.DTOs;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;
using Weelo.Core.Wrappers;
using System.Linq;

namespace Weelo.Core.Services
{
    /// <summary>
    /// Owner Service
    /// </summary>
    /// <seealso cref="IOwnerService" />
    public class OwnerService : IOwnerService
    {

        #region Propiedades

        /// <summary>
        /// The repository service
        /// </summary>
        private readonly IOwnerRepository ownerRepository;

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerService"/> class.
        /// </summary>
        /// <param name="ownerRepository">The owner repository.</param>        
        public OwnerService(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        /// <summary>
        /// Creates a new owner
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>a owner</returns>
        public async Task<Response<CreateOwnerResponse>> InsertAsync(CreateOwnerRequest request)
        {
            Owner entity = request.CreateToBase();
            var result = await this.ownerRepository.InsertAsync(entity);

            return new Response<CreateOwnerResponse>(result.CreateToModel());
        }

        /// <summary>
        /// Updates the specified owner.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>the task</returns>
        public async Task<Response<string>> Update(UpdateOwnerRequest request)
        {
            //Owner dataUpdate = owner.CreateToBase();
            var ownerEntity = this.ownerRepository.TableNoTracking.Where(x=>x.IdOwner == request.IdOwner).FirstOrDefault();

            if (ownerEntity == null)
            {
                return new Response<string>("IdOwner not found");                
            }

            ownerEntity.Name = string.IsNullOrEmpty(request.Name) ? ownerEntity.Name : request.Name.Trim();
            ownerEntity.Address = string.IsNullOrEmpty(request.Address) ? ownerEntity.Address : request.Address.Trim();
            ownerEntity.Photo = request.Photo == null ? ownerEntity.Photo :request.Photo;
            ownerEntity.Birthday = !request.Birthday.HasValue ? ownerEntity.Birthday : request.Birthday.Value;

            await this.ownerRepository.UpdateAsync(ownerEntity);
            return new Response<string>("Owner updated");

        }


        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="ownerId">The identifier.</param>
        /// <returns>the task</returns>
        public Task Delete(Int64 ownerId)
        {            
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets all owners.
        /// </summary>
        /// <returns>the list ownners</returns>
        public async Task<IList<OwnerResponse>> GetAll()
        {
            var owners = await ownerRepository.GetAll();

            return owners.Where(x => x.Active && !x.Deleted).ToList().ToModels();
        }




    }
}
