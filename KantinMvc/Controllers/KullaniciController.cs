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
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        KantinContext ctx = new KantinContext();
        public ActionResult KullaniciTanimKarti()
        {
            OnViewKullanici sov = new OnViewKullanici();
            sov.KullaniciTip = ctx.KULLANICITIPI.ToList();
            sov.Kullanicilar = ctx.KULLANICILAR.ToList();
            sov.Subeler = ctx.SUBE.ToList();
            ViewBag.count = (sov.Kullanicilar.ToList().Count);

            if (Request.IsAjaxRequest())
            {
                return PartialView("pvKullaniciList", sov);
            }
            else return View(sov);
        }
        [HttpPost]
        public bool KullaniciEkle(KULLANICILAR klc)
        {
            var kullaniciVarmi = ctx.KULLANICILAR.FirstOrDefault(x => x.KULLANICIADI == klc.KULLANICIADI);
            bool basarili = false;
            if (ModelState.IsValid && kullaniciVarmi == null)
            {
               
                klc.AKTIF = true;
                klc.SILINDI = false;
                ctx.KULLANICILAR.Add(klc);
            }
            else if (ModelState.IsValid)
            {
             
                klc.AKTIF = true;
                kullaniciVarmi.SIFRE = klc.SIFRE;
                kullaniciVarmi.SUBE_ID = klc.SUBE_ID;
                kullaniciVarmi.SILINDI = false;
                ctx.Entry(kullaniciVarmi).State = EntityState.Modified;
            }
            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                basarili = true;
            }
            return basarili;

        }
        public ActionResult KullaniciGuncelle(int? id, KULLANICILAR klc)
        {
            var Subeler = ctx.SUBE.ToList();
            var KullaniciTip = ctx.KULLANICITIPI.ToList();
            ViewBag.Subeler = Subeler;
            ViewBag.KullaniciTip = KullaniciTip;

           var kullanici = ctx.KULLANICILAR.Find(id);

            if (ModelState.IsValid)
            {
                ctx.KULLANICILAR.Add(klc);
            }
            return View(kullanici);
        }
        [HttpPost]
        public ActionResult KullaniciGuncelle(KULLANICILAR klc)
        {
           // bool basarili = false;
            try
            {
                if (ModelState.IsValid)
                {
                    klc.AKTIF = true;
                    klc.SILINDI = false;
                    ctx.Entry(klc).State = EntityState.Modified;
                    int sonuc = ctx.SaveChanges();
                    if (sonuc > 0)
                    {  return RedirectToAction("/KullaniciTanimKarti");
                      //  basarili = true;
                    }

                }
            }
            catch (DbEntityValidationException ex)
            {

                Response.Write(ex);
            }
            return View();
        }
        public ActionResult KullaniciSil(int? id)
        {

            var klc = ctx.KULLANICILAR.Find(id);
            klc.SILINDI = true;
            klc.AKTIF = false;
            ctx.Entry(klc).State = EntityState.Modified;
            ctx.SaveChanges();

            return RedirectToAction("KullaniciTanimKarti");
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

