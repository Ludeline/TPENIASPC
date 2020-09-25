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
using TpPizzaMonEssai.Models;

namespace TpPizzaMonEssai.Controllers
{
    public class PizzasController : Controller
    {
        private TpPizzaMonEssaiContext db = new TpPizzaMonEssaiContext();

        // GET: Pizzas
        public ActionResult Index()
        {
            return View(db.Pizzas.ToList());
        }

        // GET: Pizzas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // GET: Pizzas/Create
        public ActionResult Create()
        {
            PizzaViewModel pvm = new PizzaViewModel();
            pvm.Pates = db.Pates.Select(p => new SelectListItem() { Text = p.Nom, Value = p.Id.ToString() }).ToList();
            pvm.Ingredients = db.Ingredients.Select(i => new SelectListItem() { Text = i.Nom, Value = i.Id.ToString() }).ToList();
            return View(pvm);
        }

        // POST: Pizzas/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                Pizza pizza = pvm.Pizza;
                pizza.Pate = db.Pates.FirstOrDefault(p => p.Id == pvm.IdPate);
                pizza.Ingredients = db.Ingredients.Where(i => pvm.IdsIngredients.Contains(i.Id)).ToList();
                db.Pizzas.Add(pizza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pvm);
        }

        // GET: Pizzas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);
            db.Pizzas.Remove(pizza);
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
