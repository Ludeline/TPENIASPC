using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpPizzas.Models;
using TpPizzas.Utils;

namespace TpPizzas.BO
{
    public class PizzaController : Controller
    {

        // GET: Pizza
        public ActionResult Index()
        {
            return View(BDD.Instance.ListePizzas);
        }

        //GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            PizzaViewModel pvm = new PizzaViewModel();
            pvm.Pizza = BDD.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(pvm);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            //On fait appel à PizzaViewModel
            PizzaViewModel pvm = new PizzaViewModel();

            pvm.Pates = BDD.Instance.ListePates.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            pvm.Ingredients = BDD.Instance.ListeIngredients.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            return View(pvm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel pvm)
        {
            try
            {
                if (ModelState.IsValid )
                {
                    Pizza pizza = pvm.Pizza;

                    pizza.Pate = BDD.Instance.ListePates.FirstOrDefault(x => x.Id == pvm.IdPate);

                    pizza.Ingredients = BDD.Instance.ListeIngredients.Where(x => pvm.IdsIngredients.Contains(x.Id)).ToList();

                    pizza.Id = BDD.Instance.ListePizzas.Count == 0 ? 1 : BDD.Instance.ListePizzas.Max(x => x.Id) + 1;

                    BDD.Instance.ListePizzas.Add(pizza);

                    return RedirectToAction("Index");
                }
                else
                {
                    pvm.Pates = BDD.Instance.ListePates.Select(
                        x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                        .ToList();

                    pvm.Ingredients = BDD.Instance.ListeIngredients.Select(
                        x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                        .ToList();

                    return View(pvm);
                }
            }
            catch
            {
                pvm.Pates = BDD.Instance.ListePates.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

                pvm.Ingredients = BDD.Instance.ListeIngredients.Select(
                    x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                    .ToList();

                return View(pvm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaViewModel pvm = new PizzaViewModel();

            pvm.Pates = BDD.Instance.ListePates.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            pvm.Ingredients = BDD.Instance.ListeIngredients.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            pvm.Pizza = BDD.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);

            if (pvm.Pizza.Pate != null)
            {
                pvm.IdPate = pvm.Pizza.Pate.Id;
            }

            if (pvm.Pizza.Ingredients.Any())
            {
                pvm.IdsIngredients = pvm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }

            return View(pvm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel pvm)
        {
            try
            {
                Pizza pizza = BDD.Instance.ListePizzas.FirstOrDefault(x => x.Id == pvm.Pizza.Id);
                pizza.Nom = pvm.Pizza.Nom;
                pizza.Pate = BDD.Instance.ListePates.FirstOrDefault(x => x.Id == pvm.IdPate);
                pizza.Ingredients = BDD.Instance.ListeIngredients.Where(x => pvm.IdsIngredients.Contains(x.Id)).ToList();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            PizzaViewModel pvm = new PizzaViewModel();
            pvm.Pizza = BDD.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(pvm);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = BDD.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
                BDD.Instance.ListePizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
