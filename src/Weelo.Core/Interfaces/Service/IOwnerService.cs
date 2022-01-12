using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weelo.Core.DTOs;
using Weelo.Core.Wrappers;

namespace Weelo.Core.Interfaces
{
    public interface IOwnerService
    {
        /// <summary>
        /// Creates a new owner
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>a owner</returns>
        Task<Response<CreateOwnerResponse>> InsertAsync(CreateOwnerRequest request);

        /// <summary>
        /// Updates the specified owner.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>the task</returns>
        Task<Response<string>> Update(UpdateOwnerRequest request);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="ownerId">The identifier.</param>
        /// <returns>the task</returns>
        Task Delete(Int64 ownerId);



        /// <summary>
        /// Gets all owners.
        /// </summary>
        /// <returns>the list ownners</returns>
        Task<IList<OwnerResponse>> GetAll();

    }
}
