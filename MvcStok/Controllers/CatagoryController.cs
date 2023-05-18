using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class CatagoryController : Controller
    {
        // GET: Catagory
        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.tbl_katagori.ToList();

            var degerler = db.tbl_katagori.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCatagory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCatagory(tbl_katagori p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniCatagory");
            }
            db.tbl_katagori.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var katatgori = db.tbl_katagori.Find(id);
            db.tbl_katagori.Remove(katatgori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KatagoriGetir(int id)
        {
            var ktgr = db.tbl_katagori.Find(id);
            return View("KatagoriGetir", ktgr);
        }
        public ActionResult Güncelle(tbl_katagori id)
        {
            var ury = db.tbl_katagori.Find(id.KATAGORIID);
            ury.KATAGORİAD = id.KATAGORİAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}