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
    public class UrunController : Controller
    {
        // GET: Urun
        KantinContext ctx = new KantinContext();
        public ActionResult UrunGrupTanimKarti()
        {
            OnViewUrunGrubu urng = new OnViewUrunGrubu();
            urng.UrunGruplar = ctx.URUNGRUBU.ToList();


            if (Request.IsAjaxRequest())
            {
                return PartialView("pvUrunGrupList", urng);
            }
            else return View(urng);
        }
        [HttpPost]
        public bool UrunGrupEkle(URUNGRUBU s)
        {
            var urunGrubuVarmi = ctx.URUNGRUBU.FirstOrDefault(x => x.URUNGRUB == s.URUNGRUB);
            bool basarili = false;
            if (ModelState.IsValid && urunGrubuVarmi == null)
            {
                s.SILINDI = false;
                ctx.URUNGRUBU.Add(s);
            }
            else if (ModelState.IsValid)
            {
                urunGrubuVarmi.SILINDI = false;
                ctx.Entry(urunGrubuVarmi).State = EntityState.Modified;
            }
            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                basarili = true;
            }
            return basarili;

        }
        public ActionResult UrunGrupGuncelle(int? id, URUNGRUBU u)
        {

            var urunGrub = ctx.URUNGRUBU.Find(id);

            if (ModelState.IsValid)
            {
                ctx.URUNGRUBU.Add(u);
            }
            return View(urunGrub);
        }
        [HttpPost]
        public ActionResult UrunGrupGuncelle(URUNGRUBU u)
        {
            bool basarili = false;
            try
            {
                if (ModelState.IsValid)
                {
                    u.SILINDI = false;
                    ctx.Entry(u).State = EntityState.Modified;
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
            return RedirectToAction("/UrunGrupTanimKarti");
        }
        public ActionResult UrunGrupSil(int? id)
        {

            var urunGrup = ctx.URUNGRUBU.Find(id);
            urunGrup.SILINDI = true;
            ctx.Entry(urunGrup).State = EntityState.Modified;
            ctx.SaveChanges();

            return RedirectToAction("UrunGrupTanimKarti");
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

