using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products
        {
            get
            {
                return new List<Product>()
                {
                    new Product() { ID = 1, Name = "kapusta", Description = "zdrowa i zielona", Price = 3, Category= "warzywo" },
                    new Product() { ID = 2, Name = "jabłko", Description = "snamczne czerwone", Price = 1, Category = "owoc" }
                }.AsQueryable<Product>();
            }
        }

        public Product DeleteProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
