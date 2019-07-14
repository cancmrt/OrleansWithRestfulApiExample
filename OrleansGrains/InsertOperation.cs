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
    public class InsertOperation : Grain, IInsertInterface
    {
        Unit unit;
        public InsertOperation()
        {
            unit = new Unit(new ShopContext());
        }
        public Task<bool> InsertCustomer(Customer newCustomer)
        {
            unit.CustomerRepository.Insert(newCustomer);
            unit.Complete();
            return Task.FromResult(true);
        }

        public Task<bool> InsertOrder(Order newOrder)
        {
            unit.OrderRepository.Insert(newOrder);
            unit.Complete();
            return Task.FromResult(true);
        }

        public Task<bool> InsertOrderRow(OrderRow newOrderRow)
        {
            unit.OrderRowRepository.Insert(newOrderRow);
            unit.Complete();
            return Task.FromResult(true);
        }

        public Task<bool> InsertProduct(Product newProduct)
        {
            unit.ProductRepository.Insert(newProduct);
            unit.Complete();
            return Task.FromResult(true);
        }

        public Task<bool> InsertStock(Stock newStock)
        {
            unit.StockRepository.Insert(newStock);
            unit.Complete();
            return Task.FromResult(true);
        }
    }
}
