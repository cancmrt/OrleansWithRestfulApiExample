using DataDomainLayer.Entity;
using DataAccessLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.Concrete
{
    public class CustomerRepository:GenericRepository<Customer>, ICustomerRepository
    {
        ShopContext context;
        public CustomerRepository(ShopContext cx):base(cx)
        {
            context = cx;
        }

        public Customer Get(int ID)
        {
            return context.Customers
                .Where(p => p.ID == ID)
                .FirstOrDefault();
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers;
        }
    }
}
