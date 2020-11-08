using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week3.Week3HelloWorld;

namespace week3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            Week3Hello hello = new Week3Hello();
            //ViewBag.Message = hello.GetHello();

            Car car = new Car("red", 2015, "Small", "mini cooper");
            //ViewBag.Message = car.Display();

            Sedan sedan = new Sedan("blue", 2018, "Medium", "Camry");

            Dealer dealer = new Dealer("Peter", "Camberwell Toyota", "xxx Camberwell");

            sedan.Set_Dealer(dealer);
            ViewBag.Message = sedan.Display_Dealer();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}