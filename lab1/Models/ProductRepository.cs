using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testingMVC.Models
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<ShopItem> GetItems()
        {
            return new List<ShopItem>
            {
                new ShopItem() {name="kapusta", description="zielona", price=2},
                new ShopItem() {name="marchewka", description="pamarańczowa", price=4},
                new ShopItem() {name="marchewka", description="czarna", price=99}
            };
        }
    }
}
