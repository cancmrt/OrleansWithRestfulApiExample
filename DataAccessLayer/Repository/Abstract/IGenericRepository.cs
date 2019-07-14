using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        bool Insert(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(int ID);
    }
}
