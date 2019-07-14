using DataDomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository.Abstract
{
    public interface IOrderRowRepository:IGenericRepository<OrderRow>
    {
        OrderRow Get(int ID);

        IEnumerable<OrderRow> GetAll();
    }
}
