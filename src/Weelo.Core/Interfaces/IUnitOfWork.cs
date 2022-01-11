using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        public int SaveChanges();
        public Task<int> SaveChangesAsync();

        IUnitOfWorkRepository Repository { get; }
    }
}
