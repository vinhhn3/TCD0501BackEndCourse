using System.Collections.Generic;
using System.Linq;

using TCD0501BackEndCourse.Api.Data;
using TCD0501BackEndCourse.Api.Models;
using TCD0501BackEndCourse.Api.Repositories.Interface;

namespace TCD0501BackEndCourse.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }
    }
}
