using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string AutoProperty()
        {
            //Instantiation
            var myProduct = new Product();
            myProduct.Name = "Kayak";
            myProduct.ProductID = 123;
            
    
            string productname = myProduct.Name;

            return String.Format("Product name: {0}",productname);
           // return "Na"
        }
        public string CreateProduct()
        {
            //Instantiation
            var myProduct = new Product
            {
                Name = "Kayak",
                ProductID = 123,
                Description = "A boat",
                Price = 275M,
                Category = "Watersports"
            };
            // return String.Format("Category: {0}", myProduct.Category);
            //string Interpolation
            return $"Category: {myProduct.Category}";
           
        }
        public string UseExtension()
        {
            var cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name ="kayak",Price = 275M},
                    new Product { Name = "Lifejacket", Price = 48.95M },
                    new Product { Name = "Soccer Ball", Price = 19.5M },
                    new Product { Name = "Corner Flag", Price = 34.95M }
                }
            };
            decimal cartTotal = cart.TotalPrices();     
            return $"Total:{cartTotal:c}";
        }
        public string UseExtensionEnumerable()
        {
          IEnumerable<Product> product = new ShoppingCart 
                {
                Products = new List<Product>
                {
                    new Product { Name ="kayak",Price = 275M},
                    new Product { Name = "Lifejacket", Price = 48.95M },
                    new Product { Name = "Soccer Ball", Price = 19.5M },
                    new Product { Name = "Corner Flag", Price = 34.95M }
                }
            };
            decimal cartTotal = product.TotalPrices();
            return $"Total: {cartTotal:c}";
        }
        public string UseLinqQuerySyntax()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name ="kayak",
                        Category ="Watersports",
                        Price = 275M},
                    new Product { Name = "Lifejacket",
                        Category="Watersports",
                        Price = 48.95M },
                    new Product { Name = "Soccer Ball",
                        Category ="Soccer",
                        Price = 19.5M },
                    new Product { Name = "Corner Flag",
                        Category="Soccer",
                        Price = 34.95M }
                }
            };
            decimal total = 0;
            var foundProducts = from match in products
                               where match.Category == "Soccer"
                               select match;
            foreach (var prod in foundProducts)
            {
                total += prod.Price;
            }
            return $"Total: {total}";
        }
    }
}