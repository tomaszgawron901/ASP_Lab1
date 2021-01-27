using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Product DeleteProduct(int productID);
        Product AddProduct(Product product);
        void SaveProduct(Product product);
    }
}
