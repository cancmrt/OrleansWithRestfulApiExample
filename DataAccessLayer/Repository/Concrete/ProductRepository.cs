using DataDomainLayer.Entity;
using DataAccessLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        ShopContext context;
        public ProductRepository(ShopContext cx):base(cx)
        {
            context = cx;
        }

        public Product Get(int ID)
        {
            return context.Products
                .Where(p => p.ID == ID)
                .Include(p => p.STOCK)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products
                .Include(p => p.STOCK);
        }
    }
}
