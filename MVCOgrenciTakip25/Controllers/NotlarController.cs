using MVCOgrenciTakip25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOgrenciTakip25.Controllers
{
    public class NotlarController : Controller
    {
        DBLINQSORGULAR25BEntities db = new DBLINQSORGULAR25BEntities();
        public ActionResult Index()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }
        [HttpPost]
        public ActionResult YeniNot(TBLNOTLAR nott)
        {TBLNOTLAR yeninot = new TBLNOTLAR();
            yeninot.OGRENCI=nott.OGRENCI;
            yeninot.DERSID = nott.DERSID;
            yeninot.VIZE = nott.VIZE;
            yeninot.FINAL = nott.FINAL;
            yeninot.BUTUNLEME = nott.BUTUNLEME;
            decimal ortalama = Convert.ToDecimal((nott.VIZE * 0.4) + (nott.FINAL * 0.6));
            if (ortalama < 60)
            {
                yeninot.BUTUNLEME = nott.BUTUNLEME;
                ortalama = Convert.ToDecimal((nott.VIZE * 0.4) + (nott.FINAL * 0.6));
            }
            yeninot.ORTALAMA = ortalama;
            yeninot.DURUM = (ortalama <= 60) ? false : true;
            db.TBLNOTLAR.Add(yeninot);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
      

        public ActionResult NotSil(int id)
        {
            var silineceknot = db.TBLNOTLAR.Find(id);
            db.TBLNOTLAR.Remove(silineceknot);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KulupSil(int ID)//ÖDEME
        {
            TBLKULUP silinecekkulup = db.TBLKULUP.Find(ID);
            silinecekkulup.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}