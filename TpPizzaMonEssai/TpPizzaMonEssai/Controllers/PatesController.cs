using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TpPizzaMonEssai.Data;
using TpPizzaMonEssai.Entities;

namespace TpPizzaMonEssai.Controllers
{
    public class PatesController : Controller
    {
        private TpPizzaMonEssaiContext db = new TpPizzaMonEssaiContext();

        // GET: Pates
        public ActionResult Index()
        {
            return View(db.Pates.ToList());
        }

        // GET: Pates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pate pate = db.Pates.Find(id);
            if (pate == null)
            {
                return HttpNotFound();
            }
            return View(pate);
        }

        // GET: Pates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pates/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom")] Pate pate)
        {
            if (ModelState.IsValid)
            {
                db.Pates.Add(pate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pate);
        }

        // GET: Pates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pate pate = db.Pates.Find(id);
            if (pate == null)
            {
                return HttpNotFound();
            }
            return View(pate);
        }

        // POST: Pates/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom")] Pate pate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pate);
        }

        // GET: Pates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pate pate = db.Pates.Find(id);
            if (pate == null)
            {
                return HttpNotFound();
            }
            return View(pate);
        }

        // POST: Pates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pate pate = db.Pates.Find(id);
            db.Pates.Remove(pate);
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
