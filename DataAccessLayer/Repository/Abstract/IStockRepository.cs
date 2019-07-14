using DataDomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository.Abstract
{
    public interface IStockRepository:IGenericRepository<Stock>
    {
        Stock Get(int ID);

        IEnumerable<Stock> GetAll();
    }
}
