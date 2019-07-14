using DataDomainLayer.Entity;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansGrainInterfaces
{
    public interface IInsertInterface : IGrainWithStringKey
    {
        Task<bool> InsertOrder(Order newOrder);
        Task<bool> InsertOrderRow(OrderRow newOrderRow);
        Task<bool> InsertCustomer(Customer newCustomer);
        Task<bool> InsertProduct(Product newProduct);
        Task<bool> InsertStock(Stock newStock);
    }
}
