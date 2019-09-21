using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Chart()
        {
            ViewBag.Message = "Your Chart page.";

            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Mercury", 36));
            dataPoints.Add(new DataPoint("Venus", 67.2));
            dataPoints.Add(new DataPoint("Earth", 93));
            dataPoints.Add(new DataPoint("Mars", 141.6));
            dataPoints.Add(new DataPoint("Jupiter", 483.6));
            dataPoints.Add(new DataPoint("Saturn", 886.7));
            dataPoints.Add(new DataPoint("Uranus", 1784));
            dataPoints.Add(new DataPoint("Neptune", 2794.4));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }

    }
}