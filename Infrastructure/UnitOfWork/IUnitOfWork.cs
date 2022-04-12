using Infrastructure.GenericRepository;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    internal interface IUnitOfWork
    {
        IGenericRepository<Categories> Categories { get; }
        IGenericRepository<Products> Products { get; }
        void Save();
        void Dispose();
    }
}
