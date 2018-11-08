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
            return View(MyDb.Lista);
        }

        public ActionResult Create(string ujCel)
        {
            // ha visszatér valamilyen értékkel,
            if(!string.IsNullOrEmpty(ujCel))
            {
                // Akkor hozzáadjuk a listánkhoz az új tartalmat.
                MyDb.Lista.Add(new CelFeladat() { name = ujCel, done = true });
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}