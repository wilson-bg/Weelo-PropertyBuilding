using System;

namespace Weelo.Core.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        public IOwnerRepository Owners { get; protected set; }
        public IPropertyRepository Properties { get; protected set; }
    }
}
