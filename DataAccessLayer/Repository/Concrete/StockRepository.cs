using DataDomainLayer.Entity;
using DataAccessLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer.Repository.Concrete
{
    public class StockRepository:GenericRepository<Stock>, IStockRepository
    {
        ShopContext context;
        public StockRepository(ShopContext cx):base(cx)
        {
            context = cx;
        }

        public Stock Get(int ID)
        {
            return context.Stocks
                .Where(p => p.ID == ID)
                .FirstOrDefault();
        }

        public IEnumerable<Stock> GetAll()
        {
            return context.Stocks;
        }
    }
}
