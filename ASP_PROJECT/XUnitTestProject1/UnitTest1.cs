using ASP_PROJECT.Controllers;
using ASP_PROJECT.Models;
using Moq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;
using System.Threading;

namespace ASP_PROJECT_TESTS
{

    public class UnitTest1
    {
        [Fact]
        public async void GetAllProductsTest()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ID = 1, Name = "P1", Category="C1"},
                new Product {ID = 2, Name = "P2", Category="C1"},
                new Product {ID = 3, Name = "P3", Category="C2"},
                new Product {ID = 4, Name = "P4", Category="C2"},
            }.AsQueryable());

            ProductsAPIController controller = new ProductsAPIController(mock.Object);
            var okResult = (await controller.GetProducts()) as OkObjectResult;
            var result = okResult.Value as IEnumerable<Product>;

            Assert.Equal(4, result.Count());
            Assert.Equal("P1", result.ElementAt(0).Name);
            Assert.Equal("P2", result.ElementAt(1).Name);
            Assert.Equal("P3", result.ElementAt(2).Name);
            Assert.Equal("P4", result.ElementAt(3).Name);
        }


        [Fact]
        public async void GetProductsByCategoryTest()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ID = 1, Name = "P1", Category="C1"},
                new Product {ID = 2, Name = "P2", Category="C1"},
                new Product {ID = 3, Name = "P3", Category="C2"},
                new Product {ID = 4, Name = "P4", Category="C2"},
            }.AsQueryable());

            ProductsAPIController controller = new ProductsAPIController(mock.Object);
            var okResult = (await controller.GetProductsByCategory("C1")) as OkObjectResult;
            var result = okResult.Value as IEnumerable<Product>;

            Assert.Equal(2, result.Count());
            Assert.Equal("C1", result.ElementAt(0).Category);
            Assert.Equal("C1", result.ElementAt(1).Category);
            Assert.Contains(result, x => x.Name == "P1");
            Assert.Contains(result, x => x.Name == "P2");
        }

        [Theory]
        [InlineData(1, "P1")]
        [InlineData(2, "P2")]
        [InlineData(3, "P3")]
        [InlineData(4, "P4")]
        public async void GetProductByIdTest(int id, string name)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ID = 1, Name = "P1", Category="C1"},
                new Product {ID = 2, Name = "P2", Category="C1"},
                new Product {ID = 3, Name = "P3", Category="C2"},
                new Product {ID = 4, Name = "P4", Category="C2"},
            }.AsQueryable());

            ProductsAPIController controller = new ProductsAPIController(mock.Object);
            var okResult = (await controller.GetProductById(id)) as OkObjectResult;
            var result = okResult.Value as Product;

            Assert.Equal(result.Name, name);
        }
    }
}
