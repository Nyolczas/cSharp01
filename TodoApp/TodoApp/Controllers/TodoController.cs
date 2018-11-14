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

        [HttpGet] // A routing csak a get kérések esetén irányít ide.
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] // A routing csak a post kérések esetén irányít ide.
        public ActionResult Create(string name, bool isDone)
        {
            // ha visszatér valamilyen értékkel,...
            if(!string.IsNullOrEmpty(name))
            {
                // ...akkor hozzáadjuk a listánkhoz az új tartalmat.
                MyDb.Lista.Add(new CelFeladat() { name = name, done = isDone });
                return RedirectToAction("Index");
            }
            // todo: itt jelezni kell a kliensnek, hogy nem adott meg semmit!
            return View();
        }

        /// <summary>
        ///  Az Action feladata az elem megjelenítése módosításra
        ///  <param name="id"> a módosítandó tétel egyedi azonosítója</param>
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Edit( int Id)
        {
            //MyDb.Lista.Where(x => x.id == id); // leszűröm az elemeket, amelyeknek id-jük van.
            var item = MyDb.Lista.Single(x => x.id == Id); 
            return View();
        }

        [HttpPut]
        public ActionResult Edit(string name, bool isDone)
        {
            return View();
        }
    }
}