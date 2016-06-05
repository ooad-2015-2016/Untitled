using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPRRenting2.Models;

namespace ASPRRenting2
{
    public class _KorisnikController : Controller
    {
        private KorisnikDbContext db = new KorisnikDbContext();

        // GET: _Korisnik
        public ActionResult Index()
        {
            return View(db.Korisnicni.ToList());
        }

        // GET: _Korisnik/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Korisnik _Korisnik = db.Korisnicni.Find(id);
            if (_Korisnik == null)
            {
                return HttpNotFound();
            }
            return View(_Korisnik);
        }

        // GET: _Korisnik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: _Korisnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,Telefon,Adresa,Sifra,Email,SigurnosniID")] _Korisnik _Korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Korisnicni.Add(_Korisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(_Korisnik);
        }

        // GET: _Korisnik/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Korisnik _Korisnik = db.Korisnicni.Find(id);
            if (_Korisnik == null)
            {
                return HttpNotFound();
            }
            return View(_Korisnik);
        }

        // POST: _Korisnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,Telefon,Adresa,Sifra,Email,SigurnosniID")] _Korisnik _Korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(_Korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_Korisnik);
        }

        // GET: _Korisnik/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Korisnik _Korisnik = db.Korisnicni.Find(id);
            if (_Korisnik == null)
            {
                return HttpNotFound();
            }
            return View(_Korisnik);
        }

        // POST: _Korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            _Korisnik _Korisnik = db.Korisnicni.Find(id);
            db.Korisnicni.Remove(_Korisnik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
