using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;

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
            var Lista = new List<CelFeladat>();

            Lista.Add(new CelFeladat() { name = "anyagi biztonság", done = false });
            Lista.Add(new CelFeladat() { name = "anyagi függetlenség", done = false });
            Lista.Add(new CelFeladat() { name = "házépítés", done = false });
            Lista.Add(new CelFeladat() { name = "jogosítvány megszerzése", done = false });
            Lista.Add(new CelFeladat() { name = "vállalkozói karrier építése", done = false });

            return View(Lista);
        }
    }
}