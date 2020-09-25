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
    public class IngredientsController : Controller
    {
        private TpPizzaMonEssaiContext db = new TpPizzaMonEssaiContext();

        // GET: Ingredients
        public ActionResult Index()
        {
            return View(db.Ingredients.ToList());
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return HttpNotFound();
            }
            return View(ingredients);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom")] Ingredients ingredients)
        {
            if (ModelState.IsValid)
            {
                db.Ingredients.Add(ingredients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredients);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return HttpNotFound();
            }
            return View(ingredients);
        }

        // POST: Ingredients/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom")] Ingredients ingredients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredients);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return HttpNotFound();
            }
            return View(ingredients);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredients ingredients = db.Ingredients.Find(id);
            db.Ingredients.Remove(ingredients);
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
