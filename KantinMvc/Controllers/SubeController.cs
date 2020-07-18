using KantinMvc.Models;
using KantinMvc.Models.OnViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KantinMvc.Controllers
{
    public class SubeController : Controller
    {
        // GET: Sube
        KantinContext ctx = new KantinContext();
        public ActionResult SubeTanimKarti()
        {

            OnViewSube sov = new OnViewSube();
            sov.Subeler= ctx.SUBE.ToList();
            return View(sov);

        }
        [HttpPost]
        public bool SubeTanimKarti(OnViewSube s)
        {
            bool basarili = false;
            if (ModelState.IsValid)
            {
                s.sube.SILINDI = false;
                s.sube.ISLEMTARIHI = DateTime.Now;
                ctx.SUBE.Add(s.sube);
            }
            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                basarili = true;
            }
            return basarili;

        }
        public ActionResult SubeGuncelle(int? id, SUBE s)
        {

            var subeLst = ctx.SUBE.Find(id);

            if (ModelState.IsValid)
            {
                ctx.SUBE.Add(s);
            }
            return View(subeLst);
        }
        [HttpPost]
        public ActionResult SubeGuncelle(SUBE s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    s.SILINDI = false;
                    ctx.Entry(s).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return RedirectToAction("SubeTanimKarti");
                }
            }
            catch (DbEntityValidationException ex)
            {

                Response.Write(ex);
            }
            return View();
        }
        public ActionResult SubeSil(int? id)
        {

            var sube = ctx.SUBE.Find(id);
            sube.SILINDI = false;
            // ctx.SUBE.Remove(sube);
            ctx.Entry(sube).State = EntityState.Modified;
            ctx.SaveChanges();

            return RedirectToAction("SubeTanimKarti");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
