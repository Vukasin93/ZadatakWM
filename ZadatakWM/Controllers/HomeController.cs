using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZadatakWM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Zadatak za konkurs.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "email: vukasinbozic@yahoo.com      telefon: 062/383-299";

            return View();
        }
    }
}