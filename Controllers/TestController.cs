using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace testingMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public DateTime Date()
        {
            return DateTime.Now;
        }

        public RedirectResult Redirect()
        {
            return Redirect("http:\\www.google.com");
        }
    }
}
