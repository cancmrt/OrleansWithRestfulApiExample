using DataAccessLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IUnit:IDisposable
    {
        IProductRepository ProductRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        IOrderRowRepository OrderRowRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
        IStockRepository StockRepository { get; set; }

        void Complete();
    }
}
