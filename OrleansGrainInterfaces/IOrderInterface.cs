using DataDomainLayer.Entity;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansGrainInterfaces
{
    public interface IOrderInterface : IGrainWithStringKey
    {
        Task<bool> CreateOrderAsync(IEnumerable<ShopOrder> orders,int CustomerId = 0, Customer newCustomer = null);
    }
}
