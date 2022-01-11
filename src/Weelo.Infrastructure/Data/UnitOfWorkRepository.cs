using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Core.Interfaces;

namespace Weelo.Infrastructure.Data
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
       
        public UnitOfWorkRepository(WeeloContext context)
        {
            this.Owners = new OwnerRepository(context);
            this.Properties = new PropertyRepository(context);
        }

    }
}
