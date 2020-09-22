using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpPizzas.BO;

namespace TpPizzas.Utils
{
    public class BDD
    {
        private static readonly Lazy<BDD> lazy = new Lazy<BDD>(() => new BDD());

        public static BDD Instance { get { return lazy.Value; } }

        private BDD()
        {
            this.listePizzas = new List<Pizza>();
            this.GetListePizza();

            this.listeIngredients = new List<Ingredient>();
            this.GetListeIngredients();

            this.listePate = new List<Pate>();
            this.GetPate();
        }

        public List<Pizza> listePizzas { get; private set; }
        public List<Ingredient> listeIngredients { get; private set; }
        public List<Pate> listePate { get; private set; }
        public void GetListePizza()
        {
            listePizzas.Add(new Pizza { Id = 1, Ingredients = Pizza.IngredientsDisponibles, Nom = "Calzonne", Pates = Pizza.PatesDisponibles });
            listePizzas.Add(new Pizza { Id = 2, Ingredients = Pizza.IngredientsDisponibles, Nom = "Reine", Pates = Pizza.PatesDisponibles });
            listePizzas.Add(new Pizza { Id = 3, Ingredients = Pizza.IngredientsDisponibles, Nom = "Végétarienne", Pates = Pizza.PatesDisponibles });
            listePizzas.Add(new Pizza { Id = 4, Ingredients = Pizza.IngredientsDisponibles, Nom = "NoIdea", Pates = Pizza.PatesDisponibles });
        }

        public void GetListeIngredients()
        {

            listeIngredients.Add(new Ingredient { Id = 1, Nom = "Mozzarella" });
            listeIngredients.Add(new Ingredient { Id = 2, Nom = "Jambon" });
            listeIngredients.Add(new Ingredient { Id = 3, Nom = "Tomate" });
            listeIngredients.Add(new Ingredient { Id = 4, Nom = "Oignon" });
            listeIngredients.Add(new Ingredient { Id = 5, Nom = "Cheddar" });
            listeIngredients.Add(new Ingredient { Id = 6, Nom = "Saumon" });
            listeIngredients.Add(new Ingredient { Id = 7, Nom = "Champignon" });
            listeIngredients.Add(new Ingredient { Id = 8, Nom = "Poulet" });
        }

        public void GetPate()
        {

            listePate.Add(new Pate { Id = 1, Nom = "Pate fine, base crême" });
            listePate.Add(new Pate { Id = 2, Nom = "Pate fine, base tomate" });
            listePate.Add(new Pate { Id = 3, Nom = "Pate épaisse, base crême" });
            listePate.Add(new Pate { Id = 4, Nom = "Pate épaisse, base tomate" });
        }
    }
}