using EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;
        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        //Collection Initializer Syntax
        private Product[] products =
        {
            new Product {Name="Kayak",Category="Watersports",Price=275M},
            new Product {Name="Lifejacket",Category="Watersports",Price=48.95M},
            new Product {Name="Soccer Ball",Category="Soccer",Price=19.5M},
            new Product {Name="Flag",Category="Soccer",Price=34.95M}
        };
        // GET: Home
        public ActionResult Index()
        {
            //IKernel ninjectKernel = new StandardKernel(); //2
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();


            ////IValueCalculator calc = new LinqValueCalculator(); 1
            //IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            //Object Initializer Syntax
            ShoppingCart cart = new ShoppingCart(calc)
            {
                Products = products
            };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}