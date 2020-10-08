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

        public IActionResult Index()
        {
            var items = new List<ShopItem>
            {
                new ShopItem() {name="kapusta", description="zielona", price=2},
                new ShopItem() {name="marchewka", description="pamarańczowa", price=4},
                new ShopItem() {name="marchewka", description="czarna", price=99}
            };
            return View(items);
        }
    }
}
