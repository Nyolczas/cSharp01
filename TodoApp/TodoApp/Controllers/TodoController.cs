using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        public ActionResult Index()
        {
            // feladat lista 
            var Lista = new List<CelFeladat>();

            Lista.Add(new CelFeladat() { name = "anyagi biztonság", done = true });
            Lista.Add(new CelFeladat() { name = "anyagi függetlenség", done = false });
            Lista.Add(new CelFeladat() { name = "házépítés", done = false });
            Lista.Add(new CelFeladat() { name = "jogosítvány megszerzése", done = false });
            Lista.Add(new CelFeladat() { name = "vállalkozói karrier építése", done = false });

            return View(Lista);
        }
    }
}