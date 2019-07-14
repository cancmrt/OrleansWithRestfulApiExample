using DataDomainLayer.Entity;
using DataAccessLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.Concrete
{
    public class OrderRowRepository:GenericRepository<OrderRow>, IOrderRowRepository
    {
        ShopContext context;
        public OrderRowRepository(ShopContext cx):base(cx)
        {
            context = cx;
        }

        public OrderRow Get(int ID)
        {
            return context.OrderRows
               .Where(or => or.ID == ID)
               .Include(or => or.PRODUCT)
               .FirstOrDefault();
        }

        public IEnumerable<OrderRow> GetAll()
        {
            return context.OrderRows;
        }
    }
}
