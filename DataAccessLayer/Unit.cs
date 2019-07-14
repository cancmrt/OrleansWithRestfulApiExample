using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Repository.Abstract;
using DataAccessLayer.Repository.Concrete;

namespace DataAccessLayer
{
    public class Unit : IUnit
    {
        ShopContext context;
        public Unit(ShopContext cx)
        {
            context = cx;
            ProductRepository = new ProductRepository(context);
            OrderRepository = new OrderRepository(context);
            OrderRowRepository = new OrderRowRepository(context);
            CustomerRepository = new CustomerRepository(context);
            StockRepository = new StockRepository(context);
        }
        public IProductRepository ProductRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IOrderRowRepository OrderRowRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IStockRepository StockRepository { get; set; }

        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
