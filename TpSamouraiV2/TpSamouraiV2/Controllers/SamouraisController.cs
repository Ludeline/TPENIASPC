using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TpSamouraiV2.Data;
using TpSamouraiV2.Entities;
using TpSamouraiV2.Models;

namespace TpSamouraiV2.Controllers
{
    public class SamouraisController : Controller
    {
        private TpSamouraiV2Context db = new TpSamouraiV2Context();

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
            SamouraiModel sm = new SamouraiModel();
            sm.Armes = db.Armes.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            sm.ArtMartials = db.ArtMartials.Select(am => new SelectListItem() { Text = am.Nom, Value = am.Id.ToString() }).ToList();
            return View(sm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiModel sm)
        {
            if (ModelState.IsValid)
            {
                Samourai samou = sm.Samourai;
                samou.Arme = db.Armes.FirstOrDefault(a => a.Id == sm.IdArme);
                samou.ArtMartials = db.ArtMartials.Where(am => sm.IdsArtMartials.Contains(am.Id)).ToList();
                db.Samourais.Add(samou);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Samourai samourai = db.Samourais.Find(id);
            SamouraiModel sm = new SamouraiModel();
            sm.Armes = db.Armes.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            sm.ArtMartials = db.ArtMartials.Select(am => new SelectListItem() { Text = am.Nom, Value = am.Id.ToString() }).ToList();
            sm.Samourai = samourai;
            //if (samourai == null)
            //{
            //    return HttpNotFound();
            //}
            return View(sm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiModel sm)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = db.Samourais.Find(sm.Samourai.Id);
                samourai.Nom = sm.Samourai.Nom;
                samourai.Force = sm.Samourai.Force;
                samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == sm.IdArme);
                //samourai.ArtMartials = db.ArtMartials.Where(am => sm.IdsArtMartials.Contains(am.Id)).ToList();

                //Test
                foreach (var item in samourai.ArtMartials)
                {
                    db.Entry(item).State = EntityState.Modified;
                }
                samourai.ArtMartials = db.ArtMartials.Where(x => sm.IdsArtMartials.Contains(x.Id)).ToList();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sm);
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
