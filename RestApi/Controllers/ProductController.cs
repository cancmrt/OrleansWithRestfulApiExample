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
    public class ProductController : ControllerBase
    {
        private readonly IClusterClient client;
        public ProductController(IClusterClient cl)
        {
            client = cl;
        }
        // GET: api/Product
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        // GET: api/Product/5
        [HttpGet("{id}")]
        public Task<Product> Get(int id)
        {
            var getGrain = client.GetGrain<IGetInterface>(id + "-GetProduct");
            return getGrain.GetProduct(id);
        }
        
        // POST: api/Product
        [HttpPost]
        public Task<bool> Post([FromBody] Product newProduct)
        {

            var insertGrain = client.GetGrain<IInsertInterface>("InsertProduct");
            return insertGrain.InsertProduct(newProduct);

        }
        /*
        // PUT: api/Product/5
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
