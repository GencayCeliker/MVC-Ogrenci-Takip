using MVCOgrenciTakip25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOgrenciTakip25.Controllers
{
    public class DerslerController : Controller
    {
        DBLINQSORGULAR25BEntities db = new DBLINQSORGULAR25BEntities();
        // GET: Dersler
        public ActionResult Index()
        {
            var dersler=db.TBLDERS.Where(x => x.DURUM != false).ToList(); // silinen (pasif) dersler listelenmez
            return View(dersler);
        }
        public ActionResult DersEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(TBLDERS ders)
        {
            TBLDERS yeniders = new TBLDERS();
            yeniders.DERSAD = ders.DERSAD;//alan olmadığın sadece ders adı var
            db.TBLDERS.Add(yeniders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersSil(int Id)
        {
            TBLDERS silinecekders = db.TBLDERS.Find(Id);
            silinecekders.DURUM= false; // kalıcı silmek yerine pasif yap
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int Id)
        {
           var guncellenecekders = db.TBLDERS.Find(Id);//kaydı bul
            return View("DersGetir", guncellenecekders);

        }
        public ActionResult Guncelle(TBLDERS drs)
        {
            var guncders = db.TBLDERS.Find(drs);
            guncders.DERSAD = drs.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}