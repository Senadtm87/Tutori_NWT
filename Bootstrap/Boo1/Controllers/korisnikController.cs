using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Boo1.Models;

namespace Boo1.Controllers
{
    public class korisnikController : Controller
    {
        private bazaEntities db = new bazaEntities();

        //
        // GET: /korisnik/

        public ActionResult Index()
        {
            return View(db.korisniks.ToList());
        }

        //
        // GET: /korisnik/Details/5

        public ActionResult Details(int id = 0)
        {
            korisnik korisnik = db.korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        //
        // GET: /korisnik/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /korisnik/Create

        [HttpPost]
        public ActionResult Create(korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.korisniks.Add(korisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisnik);
        }

        //
        // GET: /korisnik/Edit/5

        public ActionResult Edit(int id = 0)
        {
            korisnik korisnik = db.korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        //
        // POST: /korisnik/Edit/5

        [HttpPost]
        public ActionResult Edit(korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnik);
        }

        //
        // GET: /korisnik/Delete/5

        public ActionResult Delete(int id = 0)
        {
            korisnik korisnik = db.korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        //
        // POST: /korisnik/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            korisnik korisnik = db.korisniks.Find(id);
            db.korisniks.Remove(korisnik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}