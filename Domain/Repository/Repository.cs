using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class Repository : IDisposable, IEtfRepo
    {
        private readonly EntityContainer _container;
        private bool _disposed = false;

        public Repository()
        {
            _container = new EntityContainer();
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _container.Dispose();
                }
                _disposed = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }

        #endregion

        public IObjectSet<T> GetAll<T>()
            where T : class, IEntityWithKey
        {
            return _container.CreateObjectSet<T>();
        }

        public IQueryable<T> GetAll<T>(string sortColumn, string sortOrder)
            where T : class, IEntityWithKey
        {
            if (string.IsNullOrEmpty(sortColumn))
                return GetAll<T>().AsQueryable();
            else
            {
                IOrderedQueryable<T> objectquery = _container.CreateObjectSet<T>().OrderBy("it." + sortColumn + " " + sortOrder);
                return objectquery.AsQueryable();
            }
        }

        public int Count<T>()
            where T : class, IEntityWithKey
        {
            return _container.CreateObjectSet<T>().Count();
        }

        public T Get<T>(int id)
            where T : class, IEntityWithKey
        {
            var entityKey = new EntityKey("Entities." + GetEntitySetName(typeof(T)), "Id", id);
            return _container.GetObjectByKey(entityKey) as T;
        }

        public object Get(Type entity, int id)
        {
            var entityKey = new EntityKey("Entities." + GetEntitySetName(entity), "Id", id);
            return _container.GetObjectByKey(entityKey);
        }

        public T GetLast<T>()
            where T : class, IEntityWithKey
        {
            return _container.CreateObjectSet<T>().ToList().Last();
        }

        public IQueryable<T> GetWhere<T>(Expression<Func<T, bool>> predicate)
            where T : class, IEntityWithKey
        {
            return GetAll<T>().Where(predicate);
        }

        public void Add(IEntityWithKey entity)
        {
            _container.AddObject(GetEntitySetName(entity), entity);
        }

        public void AddAll(params IEntityWithKey[] entities)
        {
            AddAll((IEnumerable<IEntityWithKey>)entities);
        }

        public void AddAll(IEnumerable<IEntityWithKey> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void AddAllAndSave(params IEntityWithKey[] entities)
        {
            AddAll(entities);
            SaveChanges();
        }

        public void Update(IEntityWithKey entity)
        {
            AttachIfNeeded(entity);
            _container.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Attach(IEntityWithKey enity)
        {
            AttachIfNeeded(enity);
        }

        private void AttachIfNeeded(IEntityWithKey entity)
        {
            if (entity.EntityKey == null)
                _container.AttachTo(GetEntitySetName(entity), entity);
        }

        public void Delete(IEntityWithKey entity)
        {
            _container.DeleteObject(entity);
        }

        public void Delete<T>(int id)
            where T : class, IEntityWithKey
        {
            var entity = Get<T>(id);
            Delete(entity);
        }

        public string GetEntitySetName(object o)
        {
            return o.GetType().Name + "s";
        }

        public string GetEntitySetName(Type type)
        {
            return type.Name + "s";
        }

        public int SaveChanges()
        {
            return _container.SaveChanges();
        }

        public void Detach(IEntityWithKey tilskudd)
        {
            _container.Detach(tilskudd);
        }
    }
}
