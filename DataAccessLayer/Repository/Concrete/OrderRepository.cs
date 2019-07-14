using DataDomainLayer.Entity;
using DataAccessLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.Concrete
{
    public class OrderRepository:GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext cx):base(cx)
        {

        }

        public Order Get(int ID)
        {
            return context.Orders
               .Where(p => p.ID == ID)
               .Include(p => p.ORDERROW)
               .ThenInclude(p => p.PRODUCT)
               .ThenInclude(p => p.STOCK)
               .Include(p => p.CUSTOMER)
               .FirstOrDefault();
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders
               .Include(p => p.ORDERROW)
               .Include(p => p.CUSTOMER);
        }
    }
}
