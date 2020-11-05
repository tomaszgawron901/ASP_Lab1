﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_PROJECT.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }

    }
}
