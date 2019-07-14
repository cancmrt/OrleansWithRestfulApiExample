using DataDomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository.Abstract
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Customer Get(int ID);

        IEnumerable<Customer> GetAll();
    }
}
