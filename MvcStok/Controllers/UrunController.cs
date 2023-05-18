using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Controllers;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var value = db.tbl_Urunler.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult YeniÜrün()
        {
            List<SelectListItem> deger = (from i in db.tbl_katagori.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KATAGORİAD,
                                              Value = i.KATAGORIID.ToString()
                                          }).ToList();
            ViewBag.der = deger;

            return View();
        }
        [HttpPost]
        public  ActionResult YeniÜrün(tbl_Urunler p3)
        {
            var ktg = db.tbl_katagori.Where(m => m.KATAGORIID == p3.tbl_katagori.KATAGORIID).FirstOrDefault();
            p3.tbl_katagori = ktg;
            db.tbl_Urunler.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urune = db.tbl_Urunler.Find(id);
            db.tbl_Urunler.Remove(urune);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var muse = db.tbl_Urunler.Find(id);

            List<SelectListItem> deger = (from i in db.tbl_katagori.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KATAGORİAD,
                                              Value = i.KATAGORIID.ToString()
                                          }).ToList();
            ViewBag.der = deger;

            return View("UrunGetir", muse);
        }
        
        public ActionResult Güncelle(tbl_Urunler id)
        {
            var urune = db.tbl_Urunler.Find(id.URUNID);
            urune.URUNAD = id.URUNAD;
            urune.MARKA = id.MARKA;
            //urune.URUNKATAGORİ = id.URUNKATAGORİ;
            var ktg = db.tbl_katagori.Where(m => m.KATAGORIID == id.tbl_katagori.KATAGORIID).FirstOrDefault();
            urune.URUNKATAGORİ = ktg.KATAGORIID;
            urune.URUNFİYAT = id.URUNFİYAT;
            urune.STOK=id.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}