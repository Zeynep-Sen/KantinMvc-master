using KantinMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KantinMvc.Controllers
{
    public class ParametreController : Controller
    {
        KantinContext ctx = new KantinContext();
        // GET: Parametre
        public ActionResult ParemetreEkle()
        {
            PARAMETRE p = new PARAMETRE();
            return View(p);
        }
        [HttpPost]
        public bool ParemetreEkle(PARAMETRE p)
        {

            bool basarili = false;
            if (ModelState.IsValid)
            {
                ctx.PARAMETRE.Add(p);
            }
            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                basarili = true;
            }
            return basarili;
        }
    }
}