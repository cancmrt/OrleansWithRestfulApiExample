using DataDomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository.Abstract
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Order Get(int ID);

        IEnumerable<Order> GetAll();
    }
}
