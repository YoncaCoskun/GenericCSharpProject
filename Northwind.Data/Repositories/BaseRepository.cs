using Northwind.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Repositories
{
    public class BaseRepository<TEntity>where TEntity:class
    {
        NorthwindContext context = new NorthwindContext();

        public void Add(TEntity obj)
        {
            context.Set<TEntity>().Add(obj);
            context.SaveChanges();
        }
        public void Remove(TEntity nesne)
        {
            context.Set<TEntity>().Remove(nesne);
            context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }
    }
}
