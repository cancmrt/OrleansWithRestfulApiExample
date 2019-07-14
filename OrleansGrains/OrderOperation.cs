using DataDomainLayer.Entity;
using Orleans;
using OrleansGrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansGrains
{
    public class OrderOperation : Grain, IOrderInterface
    {
        public async Task<bool> CreateOrderAsync(IEnumerable<ShopOrder> orders, int CustomerId = 0, Customer newCustomer = null)
        {
            Order newOrder = new Order();
            if (CustomerId != 0)
            {
                var getCustomerGrain = GrainFactory.GetGrain<IGetInterface>(CustomerId.ToString()+"-Customer");
                Customer customer = await getCustomerGrain.GetCustomer(CustomerId);
                newOrder.CUSTOMERID = customer.ID;
            }
            else if(newCustomer != null)
            {
                newOrder.CUSTOMER = newCustomer; 
            }
            else
            {
                return await Task.FromResult(false);
            }

            newOrder.NAME = Guid.NewGuid().ToString();
            newOrder.ORDERROW = new List<OrderRow>();
            foreach (ShopOrder order in orders)
            {
                

                var getProductGrain = GrainFactory.GetGrain<IGetInterface>(order.ProductId.ToString()+"-Product");
                Product product = await getProductGrain.GetProduct(order.ProductId);

                var getStockGrain = GrainFactory.GetGrain<IGetInterface>(product.STOCKID.ToString() + "-Stock");
                Stock stockOfProduct = await getProductGrain.GetStock(product.STOCKID);

             


                if(stockOfProduct.QUANTITY < order.Quantity)
                {
                    return await Task.FromResult(false);
                }
                else
                {
                    OrderRow newOrderRow = new OrderRow();
                    newOrderRow.PRODUCTID = product.ID;
                    newOrderRow.QUANTITY = order.Quantity;
                    newOrder.ORDERROW.Add(newOrderRow);
                }

            }
            var getInsertGrain = GrainFactory.GetGrain<IInsertInterface>(CustomerId.ToString()+"-InsertOrder");
            bool result = await getInsertGrain.InsertOrder(newOrder);

            return result;
        }
    }
}
