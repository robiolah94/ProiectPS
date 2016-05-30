using AgentieTorism.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AgentieTorism.Controllers
{
    public class RezervariController : Controller
    {
        private RezervariDBContext rdb = new RezervariDBContext();

        // GET: /Rezervari/
        public ActionResult Index()
        {
            return View(rdb.Rezervari.ToList());
        }

        // GET: /Rezervari/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervari rezervari = rdb.Rezervari.Find(id);
            if (rezervari == null)
            {
                return HttpNotFound();
            }
            return View(rezervari);
        }

        // GET: /Rezervari/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Rezervari/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RezervareiD,vacante,data,nrpersoane")] Rezervari rezervari)
        {
            
            if (ModelState.IsValid)
            {
                rdb.Rezervari.Add(rezervari);
                rdb.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(rezervari);
        }

        // GET: /Rezervari/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervari rezervari = rdb.Rezervari.Find(id);
            if (rezervari == null)
            {
                return HttpNotFound();
            }
            return View(rezervari);
        }

        // POST: /Rezervari/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RezervareiD,vacante,data,nrpersoane")] Rezervari rezervari)
        {
            if (ModelState.IsValid)
            {
                rdb.Entry(rezervari).State = EntityState.Modified;
                rdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezervari);
        }

        // GET: /Rezervari/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervari rezervari = rdb.Rezervari.Find(id);
            if (rezervari == null)
            {
                return HttpNotFound();
            }
            return View(rezervari);
        }

        // POST: /Rezervari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezervari Rezervari = rdb.Rezervari.Find(id);
            rdb.Rezervari.Remove(Rezervari);
            rdb.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                rdb.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}