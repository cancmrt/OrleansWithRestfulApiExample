using DataDomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Product Get(int ID);

        IEnumerable<Product> GetAll();
    }
}
