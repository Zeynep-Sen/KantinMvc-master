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
    public class SinifController : Controller
    {
        // GET: Sinif
        KantinContext ctx = new KantinContext();
        public ActionResult SinifTanimKarti()
        {
            OnViewSinif sov = new OnViewSinif();
            sov.Siniflar = ctx.SINIF.ToList();


            if (Request.IsAjaxRequest())
            {
                return PartialView("pvSinifList", sov);
            }
            else return View(sov);
        }
        [HttpPost]
        public bool SinifEkle(SINIF s)
        {
            var sinifVarmi = ctx.SINIF.FirstOrDefault(x => x.Sinif1 == s.Sinif1);
            bool basarili = false;
            if (ModelState.IsValid && sinifVarmi == null)
            {
                s.SILINDI = false;
                ctx.SINIF.Add(s);
            }
            else if (ModelState.IsValid)
            {
                sinifVarmi.SILINDI = false;
                ctx.Entry(sinifVarmi).State = EntityState.Modified;
            }
            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                basarili = true;
            }
            return basarili;

        }
        public ActionResult SinifGuncelle(int? id, SINIF s)
        {

            var sinif = ctx.SINIF.Find(id);

            if (ModelState.IsValid)
            {
                ctx.SINIF.Add(s);
            }
            return View(sinif);
        }
        [HttpPost]
        public ActionResult SinifGuncelle(SINIF s)
        {
            bool basarili = false;
            try
            {
                if (ModelState.IsValid)
                {
                    s.SILINDI = false;
                    ctx.Entry(s).State = EntityState.Modified;
                    int sonuc = ctx.SaveChanges();
                    if (sonuc > 0)
                    {
                        basarili = true;
                    }

                }
            }
            catch (DbEntityValidationException ex)
            {

                Response.Write(ex);
            }
            return RedirectToAction("/SinifTanimKarti");
        }
        public ActionResult SinifSil(int? id)
        {

            var sinif = ctx.SINIF.Find(id);
            sinif.SILINDI = true;
            ctx.Entry(sinif).State = EntityState.Modified;
            ctx.SaveChanges();

            return RedirectToAction("SinifTanimKarti");
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

