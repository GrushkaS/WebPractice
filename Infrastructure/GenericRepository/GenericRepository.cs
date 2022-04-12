using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.GenericRepository
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        DbSet<TEntity> _entities;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _entities.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _entities.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate, string[] includes)
        {
            var query = _entities.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> Get(string[] includes)
        {
            var query = _entities.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query.AsNoTracking().ToList();
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
