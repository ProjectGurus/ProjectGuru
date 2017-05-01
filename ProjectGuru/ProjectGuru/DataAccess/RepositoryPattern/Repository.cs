using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectGuru.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        private DbSet<TEntity> Set
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity item) => Set.Add(item);

        public void AddRange(IEnumerable<TEntity> items) => Set.AddRange(items);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Set.Where(predicate);

        public TEntity Get(int id) => Set.Find(id);

        public IEnumerable<TEntity> GetAll() => Set;

        public void Remove(TEntity item) => Set.Remove(item);

        public void RemoveRange(IEnumerable<TEntity> items) => Set.RemoveRange(items);
    }
}