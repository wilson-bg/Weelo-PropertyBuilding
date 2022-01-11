using System;
using System.Threading.Tasks;
using Weelo.Core.Interfaces;

namespace Weelo.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeeloContext _context;
        private bool _disposed;

        //private IOwnerRepository owners;
        //public IOwnerRepository Owners
        //{
        //    get
        //    {
        //        if (this.owners == null)
        //        {
        //            this.owners = new OwnerRepository(_context);
        //        }
        //        return owners;
        //    }
        //}

        //private IPropertyRepository properties;
        //public IPropertyRepository Properties
        //{
        //    get
        //    {
        //        if (this.properties == null)
        //        {
        //            this.properties = new PropertyRepository(_context);
        //        }
        //        return properties;
        //    }
        //}

        public IUnitOfWorkRepository Repository { get; private set; }

        public UnitOfWork(WeeloContext context)
        {
            _context = context;
            Repository = new UnitOfWorkRepository(context);
        }

        //public UnitOfWork(WeeloContext context,
        //    IOwnerRepository ownerRepository,
        //    IPropertyRepository propertiesRepository
        //    )
        //{
        //    this._context = context;
        //    this.owners = ownerRepository;
        //    this.properties = propertiesRepository;
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
