using MVCOgrenciTakip25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOgrenciTakip25.Controllers
{
   
    public class OgreciController : Controller
    {
        DBLINQSORGULAR25BEntities db = new DBLINQSORGULAR25BEntities();
        // GET: Ogreci
        public ActionResult Index()
        {
            var ogrenciler=db.TBLOGRENCİ.Where(x=>x.OGRDURUM==true).ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCİ ogr)
        {
            TBLOGRENCİ yeni = new TBLOGRENCİ();
            yeni.OGRADI = ogr.OGRADI;
            yeni.OGRSOYAD = ogr.OGRSOYAD;
            yeni.OGRKULUP = ogr.OGRKULUP; 
            yeni.OGRSINIF = ogr.OGRSINIF;
            yeni.OGRSEHIR = ogr.OGRSEHIR;
            yeni.OGRYAS = ogr.OGRYAS;
            yeni.OGRDURUM = true;
            db.TBLOGRENCİ.Add(yeni);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult OgrenciSil(int Id)
        {
            var ogrencidurumsil = db.TBLOGRENCİ.Find(Id);
            ogrencidurumsil.OGRDURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int Id)
        {
            var ogrencigetir = db.TBLOGRENCİ.Find(Id);
            return View("OgrenciGetir", ogrencigetir);
        }
        public ActionResult Guncelle(TBLOGRENCİ ogr)
        {
            var bul = db.TBLOGRENCİ.Find(ogr.OGRID);
            bul.OGRADI = ogr.OGRADI;
            bul.OGRSOYAD = ogr.OGRSOYAD;
            bul.OGRSEHIR = ogr.OGRSEHIR;
            // Güncelleme formunda olmayan alanlar boş gelir; mevcut değer korunur
            if (ogr.OGRSINIF.HasValue) bul.OGRSINIF = ogr.OGRSINIF;
            if (ogr.OGRKULUP.HasValue) bul.OGRKULUP = ogr.OGRKULUP;
            if (ogr.OGRYAS.HasValue) bul.OGRYAS = ogr.OGRYAS;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}