using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using testingMVC.Models;

namespace testingMVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository repository;
        public ShopController(IProductRepository repository) {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetItems());
        }
    }
}
