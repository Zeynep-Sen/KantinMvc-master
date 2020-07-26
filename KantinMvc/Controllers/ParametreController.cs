using KantinMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KantinMvc.Controllers
{
    public class ParametreController : Controller
    {
        KantinContext ctx = new KantinContext();
        // GET: Parametre
        public ActionResult ParemetreTanimKart()
        {   
            PARAMETRE p = new PARAMETRE();
            p = ctx.PARAMETRE.Find(1);
            return View(p);
        }
        [HttpPost]
        public bool ParemetreEkle(PARAMETRE p)
        {
            var lst = ctx.PARAMETRE.ToList();
            bool basarili = false;
            if (ModelState.IsValid &&lst.Count<1 )
            {
                ctx.PARAMETRE.Add(p);
            }
            else
            {
              
                var ps = ctx.PARAMETRE.Find(1);
                ps.KART = p.KART;
                ps.NOGIRISIZNI = p.NOGIRISIZNI;
                ps.PARABIRIMI = p.PARABIRIMI;
                ps.YUKLEMESIL = p.YUKLEMESIL;
                ps.ADI1 = p.ADI1;
                ps.ADI2 = p.ADI2;
                ps.ADI3 = p.ADI3;
                ps.ADI4 = p.ADI4;
                ps.BAKIYE_SMS = p.BAKIYE_SMS;
                ps.EKSIBAKIYESATIS = p.EKSIBAKIYESATIS;
                ps.FISHARCAMA = p.FISHARCAMA;
                ps.FISYUKLEME = p.FISYUKLEME;
                ps.PI = p.PI;           

                ctx.SaveChanges();

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