using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Infrastructure.Data
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(WeeloContext context) : base(context)
        {
        }

    }
}
