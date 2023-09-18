using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace BussinessLayer
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private EntityConnection connection;
        private DbSet<T> objectset;
        public Repository()
        {
            connection = new EntityConnection();
            objectset = connection.Set<T>();
        }
        public int Add(T Entity)
        {
            objectset.Add(Entity);
            return connection.SaveChanges();
        }

        public int Delete(int id)
        {
            objectset.Remove(Get(id));
            return connection.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return objectset.FirstOrDefault(expression);
        }
        public T Get(int id)
        {
            return objectset.Find(id);
        }

        public List<T> GetAll()
        {
            return objectset.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return objectset.Where(expression).ToList();
        }

        public int Update(T Entity)
        {
            objectset.AddOrUpdate(Entity);
            return connection.SaveChanges();
        }
    }
}
