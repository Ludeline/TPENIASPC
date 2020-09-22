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
            return View(BDD.Instance.listePizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizzas = BDD.Instance.listePizzas.FirstOrDefault(p => p.Id == id);
            return View(pizzas);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            //On fait appel à PizzaViewModel
            PizzaViewModel vm = new PizzaViewModel();

            vm.Pates = BDD.Instance.listePate.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();

            vm.Ingredients = BDD.Instance.listeIngredients.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel vm)
        {
            try
            {
                Pizza pizza = vm.Pizza;
                pizza.Pate = BDD.Instance.listePate.FirstOrDefault(p => p.Id == vm.IdPate);

                pizza.Ingredients = BDD.Instance.listeIngredients.Where(i => vm.IdsIngredients.Contains(i.Id)).ToList();

                pizza.Id = BDD.Instance.listePizzas.Count == 0 ? 1 : BDD.Instance.listePizzas.Max(p => p.Id) + 1;

                BDD.Instance.listePizzas.Add(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                vm.Pates = BDD.Instance.listePate.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();

                vm.Ingredients = BDD.Instance.listeIngredients.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();

                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaViewModel vm = new PizzaViewModel();

            vm.Pizza = BDD.Instance.listePizzas.FirstOrDefault(piz => piz.Id == id);

            vm.Pates = BDD.Instance.listePate.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();

            vm.Ingredients = BDD.Instance.listeIngredients.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();

            //Bout de code du formateur
            //Si pas ces vérifications ça me pète un nullPointer exception aussi

            if (vm.Pizza.Pate != null)
            {
                vm.IdPate = vm.Pizza.Pate.Id;
            }

            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdsIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }
            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel vm)
        {
            try
            {
                Pizza pizz = BDD.Instance.listePizzas.FirstOrDefault(piz => piz.Id == vm.Pizza.Id);
                pizz.Nom = vm.Pizza.Nom;
                pizz.Pate = BDD.Instance.listePate.FirstOrDefault(pate => pate.Id == vm.IdPate);
                pizz.Ingredients = BDD.Instance.listeIngredients.Where(i => vm.IdsIngredients.Contains(i.Id)).ToList();

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
            Pizza pizzas = BDD.Instance.listePizzas.FirstOrDefault(p => p.Id == id);
            return View(pizzas);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizzas = BDD.Instance.listePizzas.FirstOrDefault(p => p.Id == id);
                BDD.Instance.listePizzas.Remove(pizzas);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
