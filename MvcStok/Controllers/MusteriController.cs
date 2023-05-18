using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var item = from d in db.tbl_musteri select d;
            if(!string.IsNullOrEmpty(p))
            {
                item = item.Where(n=>n.MUSTERİAD.Contains(p));
            }
            return View(item.ToList());
            //var value = db.tbl_musteri.ToList();
            //return View(value);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tbl_musteri p2)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tbl_musteri.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Sil(int id)
        {
            var mus = db.tbl_musteri.Find(id);
            db.tbl_musteri.Remove(mus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Musterigetir(int id)
        {
            var musd = db.tbl_musteri.Find(id);
            return View("Musterigetir", musd);
        }
        public ActionResult Güncelle(tbl_musteri id)
        {
            var mmus = db.tbl_musteri.Find(id.MUSTERİID);
            mmus.MUSTERİAD = id.MUSTERİAD;
            mmus.MUSTERİSOYAD = id.MUSTERİSOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}