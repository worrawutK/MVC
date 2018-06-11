﻿using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Kayak",
            Description = "A boat",
            Category = "Watersports",
            Price = 275M
        };
        // GET: Home
        public ActionResult Index()
        {
            return View(myProduct);
        }
        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }
        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;
            return View(myProduct);
        }
        public ActionResult DemoArray()
        {
            Product[] array = {
                new Product {Name="Kayak",Price=275M},
                new Product {Name="Lifejacket",Price=48.95M},
                new Product {Name="Soccer Ball",Price=19.5M},
                new Product {Name="Flag",Price=34.95M}
            };
            return View(array);
        }
    }
}