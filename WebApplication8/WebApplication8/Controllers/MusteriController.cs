using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models.Entity;

namespace WebApplication8.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStok2Entities db = new MvcDbStok2Entities();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERI.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERI p1)
        {
            db.TBLMUSTERI.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERI.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBLMUSTERI p1)
        {
            var musteri = db.TBLMUSTERI.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}