using AdidasHack.Core.Entities;
using System.Collections;
using System.Collections.Generic;

namespace AdidasHack.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : class, IBaseEntityIdentity
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        bool SaveChanges();
    }
}
