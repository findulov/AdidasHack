using System.Collections.Generic;
using System.Linq;
using AdidasHack.Core.Entities;
using AdidasHack.Infrastructure.Repositories;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntityIdentity
    {
        protected readonly AdidasDbContext db;

        public BaseRepository(AdidasDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            db.Add(entity);
        }

        public void Delete(T entity)
        {
            db.Remove(entity);
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }
    }
}
