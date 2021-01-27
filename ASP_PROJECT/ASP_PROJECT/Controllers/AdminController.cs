using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_PROJECT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_PROJECT.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
             return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            return View(repository.Products.FirstOrDefault(p => p.ID == productId));
        }
            

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"Zapisano {product.Name}.";
                return RedirectToAction("Index");
            }
            else
            {
                // Błąd w wartościach danych.
                return View("Edit", product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"Usunięto {deletedProduct.Name}.";
            }
            return RedirectToAction("Index");
        }
    }
}
