using DataDomainLayer.Entity;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansGrainInterfaces
{
    public interface IGetInterface : IGrainWithStringKey
    {
        Task<Order> GetOrder(int OrderId);
        Task<OrderRow> GetOrderRow(int OrderRowId);
        Task<Customer> GetCustomer(int CustomerId);
        Task<Product> GetProduct(int ProductId);
        Task<Stock> GetStock(int StockId);
    }
}
