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
    public class CariController : Controller
    {
        // GET: Cari
        KantinContext ctx = new KantinContext();
        public ActionResult CariTanimKarti()
        {
            OnViewCari cov = new OnViewCari();
            cov.Cariler = ctx.CARIKART.ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("pvCariList", cov);
            }
            else return View(cov);
        }
        [HttpPost]
        public bool CariEkle(CARIKART c)
        {
            var cariVarmi = ctx.CARIKART.FirstOrDefault(x => x.TELEFON == c.TELEFON);
            bool basarili = false;
            if (ModelState.IsValid && cariVarmi == null)
            {
                c.SILINDI = false;
                ctx.CARIKART.Add(c);
            }
            else if (ModelState.IsValid)
            {
                c.ISLEMTARIHI = DateTime.Now;
                cariVarmi.SILINDI = false;
                ctx.Entry(cariVarmi).State = EntityState.Modified;
            }
            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                basarili = true;
            }
            return basarili;

        }
        public ActionResult CariGuncelle(int? id, CARIKART c)
        {

            var cari = ctx.CARIKART.Find(id);

            if (ModelState.IsValid)
            {
                ctx.CARIKART.Add(c);
            }
            return View(cari);
        }
        [HttpPost]
        public ActionResult CariGuncelle(CARIKART c)
        {
            bool basarili = false;
            try
            {
                if (ModelState.IsValid)
                {
                    c.SILINDI = false;
                    ctx.Entry(c).State = EntityState.Modified;
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

            return RedirectToAction("/CariTanimKarti");
        }
        public ActionResult CariSil(int? id)
        {

            var cari = ctx.CARIKART.Find(id);
            cari.SILINDI = true;
            ctx.Entry(cari).State = EntityState.Modified;
            ctx.SaveChanges();

            return RedirectToAction("CariTanimKarti");
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

