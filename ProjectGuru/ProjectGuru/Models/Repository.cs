using System.Collections.Generic;
using System.Linq;

namespace ProjectGuru.Models
{
    public class Repository<TEntity> where TEntity : class
    {
        protected DataBase db;

        public Repository(DataBase db)
        {
            this.db = db;
        }

        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public virtual TEntity Find<TKey>(TKey key)
        {
            return db.Set<TEntity>().Find(key);
        }

        public void Add(TEntity item)
        {
            db.Set<TEntity>().Add(item);
        }

        public void Remove<TKey>(TKey key)
        {
            db.Set<TEntity>().Remove(db.Set<TEntity>().Find(key));
        }

        public void Persist()
        {
            db.SaveChanges();
        }
    }
}