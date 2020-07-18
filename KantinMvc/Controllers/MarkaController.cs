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
    public class MarkaController : Controller
    {
        // GET: Marka
        KantinContext ctx = new KantinContext();
        public ActionResult MarkaTanimKarti()
        {    
            OnViewMarka mov = new OnViewMarka();
            mov.Markalar = ctx.MARKA.ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("pvMarkaList",mov);
            }
            else return View(mov);
        }
        [HttpPost]
        public bool MarkaEkle(MARKA m)
        {
            var markaVarmi = ctx.MARKA.FirstOrDefault(x => x.MARKA1 == m.MARKA1 );
            bool basarili = false;
            if (ModelState.IsValid && markaVarmi == null)
            {
                m.SILINDI = false;
                ctx.MARKA.Add(m);
            }
            else if (ModelState.IsValid)
            {
                markaVarmi.SILINDI = false;
                ctx.Entry(markaVarmi).State = EntityState.Modified;
            }
            int sonuc = ctx.SaveChanges();
            if (sonuc>0)
            {
               basarili=true;
            }
            return basarili;

        }
        public ActionResult MarkaGuncelle(int? id, MARKA m)
        {

            var marka = ctx.MARKA.Find(id);

            if (ModelState.IsValid)
            {
                ctx.MARKA.Add(m);
            }
            return View(marka);
        }
        [HttpPost]
        public bool MarkaGuncelle(MARKA m)
        {
            bool basarili = false;
            try
            {
                if (ModelState.IsValid)
                {
                    m.SILINDI = false;
                    ctx.Entry(m).State = EntityState.Modified;
                   int sonuc= ctx.SaveChanges();
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
            return basarili;
        }
        public ActionResult MarkaSil(int? id)
        {

            var marka = ctx.MARKA.Find(id);
            marka.SILINDI = true;
           // ctx.MARKA.Remove(marka);
            ctx.Entry(marka).State = EntityState.Modified;
            ctx.SaveChanges();
            
            return RedirectToAction("MarkaTanimKarti");
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
    
