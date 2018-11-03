using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult FeladatLista()
        {
            // feladat lista 
            var Lista = new List<string>();

            Lista.Add("anyagi biztonság");
            Lista.Add("anyagi függetlenség");
            Lista.Add("házépítés");
            Lista.Add("jogosítvány megszerzése");
            Lista.Add("vállalkozói karrier építése");

            

            return View();
        }
    }
}