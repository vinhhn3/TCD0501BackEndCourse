using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using TCD0501BackEndCourse.Api.Data;
using TCD0501BackEndCourse.Api.Models;
using TCD0501BackEndCourse.Api.Repositories;

namespace TCD0501BackEndCourse.UnitTests
{
    [TestFixture]
    class ProductRepositoryTest
    {
        private ProductRepository _repository;
        private DbContextOptions<ApplicationDbContext> _options;
        private ApplicationDbContext _context;
        [OneTimeSetUp]
        public void Setup()
        {
            // Config options to create in-memory database
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(_options);

            // Add data to in-memory database
            _context.Categories.Add(
                new Category
                {
                    Name = "Test"
                }
                );

            _context.Products.Add(new Product
            {

                Name = "Phone Test 1",
                CategoryId = 1,
                Description = "Desc Test 1",
                Price = 10
            });

            _context.Products.Add(new Product
            {

                Name = "Phone Test 2",
                CategoryId = 1,
                Description = "Desc Test 2",
                Price = 20
            });

            _context.Products.Add(new Product
            {

                Name = "Phone Test 3",
                CategoryId = 1,
                Description = "Desc Test 3",
                Price = 30
            });

            _context.SaveChanges();

            // Create Repository Object
            _repository = new ProductRepository(_context);
        }

        [Test]
        [Order(1)]
        public void GetProducts_WhenCalled_ReturnAllProductsInDatabase()
        {
            // Arrange

            // Act
            var products = _repository.GetProducts();

            // Assert
            Assert.That(products.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(products[0].Name, Is.EqualTo("Phone Test 1"));
                Assert.That(products[0].CategoryId, Is.EqualTo(1));
                Assert.That(products[0].Description, Is.EqualTo("Desc Test 1"));
                Assert.That(products[0].Price, Is.EqualTo(10));
            });
        }
    }
}
