using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TpSamurai.Data;
using TpSamurai.Entities;
using TpSamurai.Models;

namespace TpSamurai.Controllers
{
    public class SamouraisController : Controller
    {
        private TpSamuraiContext db = new TpSamuraiContext();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SAmouraiModelcs sm = new SAmouraiModelcs();
            sm.Armes = db.Armes.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            return View(sm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SAmouraiModelcs sm)
        {
            if (ModelState.IsValid)
            {
                //Pizza pizza = vm.Pizza;
                //pizza.Pate = BDD.Instance.listePate.FirstOrDefault(p => p.Id == vm.IdPate);
                Samourai samou = sm.Samourai;
                samou.Arme = db.Armes.FirstOrDefault(a => a.Id == sm.IdArme);
                //sm.Armes = db.Armes.FirstOrDefault(a => a.Id == sm.IdArme.Value);
                //sm.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
                db.Samourais.Add(samou);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Force,Nom")] Samourai samourai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samourai);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
