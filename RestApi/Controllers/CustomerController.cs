using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataDomainLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using OrleansGrainInterfaces;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IClusterClient client;
        public CustomerController(IClusterClient cl)
        {
            client = cl;
        }
        /*// GET: api/Customer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public Task<Customer> Get(int id)
        {
            var getGrain = client.GetGrain<IGetInterface>(id + "-GetCustomer");
            return getGrain.GetCustomer(id);
        }

        // POST: api/Customer
        [HttpPost]
        public Task<bool> Post([FromBody] Customer newCustomer)
        {
            var getGrain = client.GetGrain<IInsertInterface>("InsertCustomer");
            return getGrain.InsertCustomer(newCustomer);
        }

        /*// PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
