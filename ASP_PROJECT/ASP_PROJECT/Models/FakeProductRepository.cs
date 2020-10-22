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
                    new Product() { ID = 1, name = "kapusta", description = "zdrowa i zielona", price = 3, type = "warzywo" },
                    new Product() { ID = 2, name = "jabłko", description = "snamczne czerwone", price = 1, type = "owoc" }
                }.AsQueryable<Product>();
            }
        }
    }
}
