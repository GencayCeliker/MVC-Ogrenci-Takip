using MVCOgrenciTakip25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOgrenciTakip25.Controllers
{
    public class KulupController : Controller
    {
        // GET: Kulup
        DBLINQSORGULAR25BEntities db = new DBLINQSORGULAR25BEntities();
        public ActionResult Index()
        {
            var kulup = db.TBLKULUP.Where(x=>x.Durum==true).ToList();
            return View(kulup);
        }
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBLKULUP kulup)
        {
            TBLKULUP yenikulup = new TBLKULUP();

            yenikulup.KULUPADI = kulup.KULUPADI;
            yenikulup.Durum = true;

            db.TBLKULUP.Add(yenikulup);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult KulupSil(int ID)
        {
            TBLKULUP silinecekkulup = db.TBLKULUP.Find(ID);
            silinecekkulup.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int ID)
        {
            var kulupgetir = db.TBLKULUP.Find(ID);
            return View("KulupGetir", kulupgetir);
        }
        public ActionResult KulupGuncelle(TBLKULUP klp)
        {
            var guncelleneckulup = db.TBLKULUP.Find(klp.KULUPID);
            guncelleneckulup.KULUPADI = klp.KULUPADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}