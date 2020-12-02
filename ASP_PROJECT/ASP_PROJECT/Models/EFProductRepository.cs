using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT.Models
{
    public class EFProductRepository: IProductRepository
    {
        private readonly AppDbContext ctx;
        public EFProductRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<Product> Products => ctx.Products;

        public Product DeleteProduct(int productID)
        {
            var existingProduct = this.ctx.Products.FirstOrDefault(p => p.ID == productID);
            if (existingProduct != null)
            {
                this.ctx.Remove(existingProduct);
            }
            return existingProduct;
        }

        public void SaveProduct(Product product)
        {
            if (product.ID == 0)
            {
                this.ctx.Products.Add(product);
            }
            else
            {
                var existingProduct = this.ctx.Products.FirstOrDefault( p => p.ID == product.ID);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Category = product.Category;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                }
            }
            this.ctx.SaveChanges();
        }
    }
}
