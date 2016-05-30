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
    public class VacanteController : Controller
    {
        public VacanteDBContext vdb = new VacanteDBContext();

        // GET: /Spectacole/
        public ActionResult Index()
        {
            return View(vdb.Vacante.ToList());
        }

        // GET: /Spectacole/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = vdb.Vacante.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            return View(vacante);
        }

        // GET: /Spectacole/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Spectacole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VacanteiD,Tara,Destinatia,Duratasejur,transport,pachet,plecare,locuridisponible")] Vacante vacante)
        {
            if (ModelState.IsValid)
            {
                vdb.Vacante.Add(vacante);
                vdb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacante);
        }

        // GET: /Spectacole/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante spectacole = vdb.Vacante.Find(id);
            if (spectacole == null)
            {
                return HttpNotFound();
            }
            return View(spectacole);
        }

        // POST: /Spectacole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "VacanteiD,Tara,Destinatia,Duratasejur,trasnport,pachet,plecare,locuridisponible")] Vacante vacante)
        {
            if (ModelState.IsValid)
            {
                vdb.Entry(vacante).State = EntityState.Modified;
                vdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacante);
        }

        // GET: /Spectacole/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacante vacante = vdb.Vacante.Find(id);
            if (vacante == null)
            {
                return HttpNotFound();
            }
            return View(vacante);
        }

        // POST: /Spectacole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacante vacante = vdb.Vacante.Find(id);
            vdb.Vacante.Remove(vacante);
            vdb.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                vdb.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}