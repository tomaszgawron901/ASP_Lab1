using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_PROJECT.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult List(string category) {
            if (category != null && category.Length > 0)
            {
                return View(repository.Products.Where(p => p.Category == null || p.Category == category));
            }
            return View(repository.Products);
        } 

        public ViewResult ListAll() => View(repository.Products);
    }
}
