using Infrastructure.GenericRepository;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IGenericRepository<Categories> categories;

        private IGenericRepository<Products> products;

        private ApplicationContext db;

        internal UnitOfWork()
        {
            db = new ApplicationContext();
        }

        ~UnitOfWork()
        {
            this.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IGenericRepository<Categories> Categories
        {
            get { 
                if(categories == null)
                    categories = new GenericRepository<Categories>(db);
                return categories;
            }
        }
        public IGenericRepository<Products> Products
        {
            get
            {
                if(products == null)
                    products = new GenericRepository<Products>(db);
                return products;
            }
        }

        private bool disposed = false;
        internal virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
