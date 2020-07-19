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
        
           
            if (Request.IsAjaxRequest())
            {
                return PartialView("pvSubeList", sov);
            }
            else return View(sov);
        }
        [HttpPost]
        public bool SubeEkle(SUBE s)
        {
            var subeVarmi = ctx.SUBE.FirstOrDefault(x => x.ADI == s.ADI);
            bool basarili = false;
            if (ModelState.IsValid && subeVarmi == null)
            {
                s.ISLEMTARIHI = DateTime.Now;
                s.SILINDI = false;
                ctx.SUBE.Add(s);
            }
            else if (ModelState.IsValid)
            {
                s.ISLEMTARIHI = DateTime.Now;
                subeVarmi.SILINDI = false;
                ctx.Entry(subeVarmi).State = EntityState.Modified;
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

            var sube= ctx.SUBE.Find(id);

            if (ModelState.IsValid)
            {
                ctx.SUBE.Add(s);
            }
            return View(sube);
        }
        [HttpPost]
        public ActionResult SubeGuncelle(SUBE s)
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
            return RedirectToAction("/SubeTanimKarti");
        }
        public ActionResult SubeSil(int? id)
        {

            var sube = ctx.SUBE.Find(id);
            sube.SILINDI = true;
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

