using MVCOgrenciTakip25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOgrenciTakip25.Controllers
{

    public class UrunlerController : Controller
    {
        DBLINQSORGULAR25BEntities db = new DBLINQSORGULAR25BEntities();
        // GET: Urunler
        public ActionResult Index()
        {
            var urunler = db.TBLURUN.ToList();
            return View(urunler);

        }
        public ActionResult YeniUrun()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUN urun)
        {
            TBLURUN yeniurun = new TBLURUN();

            yeniurun.URUNADI = urun.URUNADI;
            yeniurun.MARKA = urun.MARKA;
            yeniurun.STOKADET = urun.STOKADET;
            

            db.TBLURUN.Add(yeniurun);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult UrunSil(int ID)
        {
            TBLURUN silinecekurun = db.TBLURUN.Find(ID);
            db.TBLURUN.Remove(silinecekurun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int ID)
        {
            var urungetir = db.TBLURUN.Find(ID);
            return View("UrunGetir", urungetir);
        }
        public ActionResult UrunGuncelle(TBLURUN urun)
        {
            var guncelleneckulup = db.TBLURUN.Find(urun.ID);
            guncelleneckulup.URUNADI = urun.URUNADI;
            guncelleneckulup.STOKADET = urun.STOKADET;
            guncelleneckulup.MARKA = urun.MARKA;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}