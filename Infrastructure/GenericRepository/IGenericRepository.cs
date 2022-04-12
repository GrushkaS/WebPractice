using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class 
    {
        void Add(TEntity entity);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate, string[] includes);
        public IEnumerable<TEntity> Get(string[] includes);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
