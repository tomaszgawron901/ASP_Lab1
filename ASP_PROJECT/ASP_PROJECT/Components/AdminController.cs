using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_PROJECT.Components
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _repository;

        public AdminController(IProductRepository repo)
        {
            this._repository = repo;
        }

        public ViewResult Index() => View(this._repository.Products);

        public ViewResult Edit(int productID) => View(
            this._repository.Products.FirstOrDefault(p => p.ID == productID)
        );

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                this._repository.SaveProduct(product);
                TempData["message"] = $"Zapisano {product.Name}.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", product);
            }
        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = _repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"Usunięto produkt o nazwie: {deletedProduct.Name}";
            }
            return RedirectToAction("Index");
        }

    }
}
