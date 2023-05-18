using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatışController : Controller
    {
        // GET: Satış
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatıs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatıs(tbl_satıs p)
        {
            db.tbl_satıs.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}