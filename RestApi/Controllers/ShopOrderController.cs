using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataDomainLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Orleans;
using OrleansGrainInterfaces;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopOrderController : ControllerBase
    {
        // GET api/values
        private readonly IClusterClient client;
        public ShopOrderController(IClusterClient cl)
        {
            client = cl;
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public Task<Order> Get(int id)
        {
            var orderGrain = client.GetGrain<IGetInterface>(id.ToString()+"-OrderDetail");
            return orderGrain.GetOrder(id);
        }

        // POST api/values

        [HttpPost("{customerId}")]
        public Task<bool> Post([FromBody] IEnumerable<ShopOrder> newOrder, int customerId)
        {
            var orderGrain = client.GetGrain<IOrderInterface>(customerId.ToString()+"-Order");
            return orderGrain.CreateOrderAsync(newOrder, customerId);
        }

        // PUT api/values/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
