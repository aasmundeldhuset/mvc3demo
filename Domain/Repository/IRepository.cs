using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public interface IRepository
    {
        IObjectSet<T> GetAll<T>() where T : class, IEntityWithKey;
        IQueryable<T> GetAll<T>(string sortColumn, string sortOrder) where T : class, IEntityWithKey;
        int Count<T>() where T : class, IEntityWithKey;
        T Get<T>(int id) where T : class, IEntityWithKey;
        IQueryable<T> GetWhere<T>(Expression<Func<T, bool>> predicate) where T : class, IEntityWithKey;
        void Add(IEntityWithKey entity);
        void AddAll(IEnumerable<IEntityWithKey> entities);
        void AddAll(params IEntityWithKey[] entities);
        void AddAllAndSave(params IEntityWithKey[] entities);
        void Update(IEntityWithKey entity);
        void Delete(IEntityWithKey entity);
        void Delete<T>(int id) where T : class, IEntityWithKey;
        int SaveChanges();
        void Detach(IEntityWithKey tilskudd);
        void Attach(IEntityWithKey enity);
    }
}
