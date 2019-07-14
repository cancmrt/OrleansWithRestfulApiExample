using DataAccessLayer;
using DataDomainLayer.Entity;
using Orleans;
using OrleansGrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansGrains
{
    public class GetOperation : Grain, IGetInterface
    {
        Unit unit;
        public GetOperation()
        {
            unit = new Unit(new ShopContext());
        }
        public Task<Customer> GetCustomer(int CustomerId)
        {
            Customer result = unit.CustomerRepository.Get(CustomerId);
            return Task.FromResult(result);
        }

        public Task<Order> GetOrder(int OrderId)
        {
            Order result = unit.OrderRepository.Get(OrderId);
            return Task.FromResult(result);
        }

        public Task<OrderRow> GetOrderRow(int OrderRowId)
        {
            OrderRow result = unit.OrderRowRepository.Get(OrderRowId);
            return Task.FromResult(result);
        }

        public Task<Product> GetProduct(int ProductId)
        {
            Product result = unit.ProductRepository.Get(ProductId);
            return Task.FromResult(result);
        }

        public Task<Stock> GetStock(int StockId)
        {
            Stock result = unit.StockRepository.Get(StockId);
            return Task.FromResult(result);
        }
    }
}
