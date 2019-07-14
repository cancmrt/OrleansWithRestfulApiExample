
using DataAccessLayer.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        public ShopContext context;
        public GenericRepository(ShopContext cx)
        {
            context = cx;
        }
        public bool Delete(int ID)
        {
            context.Set<TEntity>().Remove(context.Set<TEntity>().Find(ID));
            return true;
        }

        public bool Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return true;
        }

        public bool Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return true;
        }

    }
}
