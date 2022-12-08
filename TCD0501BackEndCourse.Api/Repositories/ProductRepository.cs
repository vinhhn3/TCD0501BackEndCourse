using Microsoft.EntityFrameworkCore;

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

        public bool Create(Product product)
        {
            try
            {
                var newProduct = new Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                };

                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var product = GetProduct(id);
            if (product == null) return false;
            try
            {
                _context.Remove(product);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Edit(int id, Product product)
        {
            var productInDb = GetProduct(id);
            if (productInDb == null) return false;
            if (productInDb.Id != product.Id) return false;

            try
            {
                productInDb.Name = product.Name;
                productInDb.Description = product.Description;
                productInDb.Price = product.Price;
                productInDb.CategoryId = product.CategoryId;
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }

        public Product GetProduct(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
            return product;
        }

        public List<Product> GetProducts()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .ToList();
            return products;
        }
    }
}
