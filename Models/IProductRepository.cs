using System.Collections.Generic;

namespace testingMVC.Models
{
    public interface IProductRepository
    {
        IEnumerable<ShopItem> GetItems();
    }
}