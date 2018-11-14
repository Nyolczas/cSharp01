using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class MyDb
    {
        /// <summary>
        /// Ideiglenes barkács megoldás a végleges adatbázis elkészültéig
        /// </summary>
        public static List<CelFeladat> Lista = new List<CelFeladat>
            {
                new CelFeladat() { id=0, name = "anyagi biztonság", done = true },
                new CelFeladat() { id=1, name = "anyagi függetlenség", done = false },
                new CelFeladat() { id=2, name = "házépítés", done = false },
                new CelFeladat() { id=3, name = "jogosítvány megszerzése", done = false },
                new CelFeladat() { id=4, name = "vállalkozói karrier építése", done = false }
            };
    }
}