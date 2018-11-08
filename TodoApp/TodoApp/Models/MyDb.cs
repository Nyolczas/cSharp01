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
                new CelFeladat() { name = "anyagi biztonság", done = true },
                new CelFeladat() { name = "anyagi függetlenség", done = false },
                new CelFeladat() { name = "házépítés", done = false },
                new CelFeladat() { name = "jogosítvány megszerzése", done = false },
                new CelFeladat() { name = "vállalkozói karrier építése", done = false }
            };
    }
}