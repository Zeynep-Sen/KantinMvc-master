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
    public class MenuController : Controller
    {
        // GET: Menu
        KantinContext ctx = new KantinContext();
        public ActionResult MenuTanimKarti()
        {
            OnViewMenu mov = new OnViewMenu();
            mov.Menuler = ctx.MENUTANIM.ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("pvMenuList", mov);
            }
            else return View(mov);
        }
        [HttpPost]
        public bool MenuEkle(MENUTANIM m)
        {
            bool basarili = false;
            if (ModelState.IsValid)
            {
                ctx.MENUTANIM.Add(m);
            }
            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                basarili = true;
            }
            return basarili;

        }
        public ActionResult MenuGuncelle(int? id, MENUTANIM m)
        {

            var menu = ctx.MENUTANIM.Find(id);

            if (ModelState.IsValid)
            {
                ctx.MENUTANIM.Add(m);
            }
            return View(menu);
        }
        [HttpPost]
        public ActionResult MenuGuncelle(MENUTANIM m)
        {
            bool basarili = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.Entry(m).State = EntityState.Modified;
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
            return RedirectToAction("/MenuTanimKarti");
        }
        public ActionResult MenuSil(int? id)
        {

            var menu = ctx.MENUTANIM.Find(id);
            ctx.MENUTANIM.Remove(menu);
            ctx.SaveChanges();

            return RedirectToAction("MenuTanimKarti");
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

