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
            this.ListeIngredients = this.GetListeIngredients();
            this.ListePates = this.GetPate();
            this.ListePizzas = new List<Pizza>();
        }

        private List<Ingredient> ingredients;

        public List<Ingredient> ListeIngredients
        {
            get { return ingredients; }
            private set { this.ingredients = value; }
        }

        private List<Pate> pates;

        public List<Pate> ListePates
        {
            get { return pates; }
            private set { this.pates = value; }
        }

        private List<Pizza> pizzas;

        public List<Pizza> ListePizzas
        {
            get { return pizzas; }
            private set { pizzas = value; }
        }
        //public List<Pizza> GetListePizza()
        //{
        //    List<Pizza> listepizza = new List<Pizza>();

        //    listepizza.Add(new Pizza { Id = 1, Ingredients = Pizza.IngredientsDisponibles, Nom = "Calzonne", Pate = Pizza.PatesDisponibles.Contains(i => i.Id).ToList());
        //    listepizza.Add(new Pizza { Id = 2, Ingredients = Pizza.IngredientsDisponibles, Nom = "Reine", Pate = Pizza.PatesDisponibles });
        //    listepizza.Add(new Pizza { Id = 3, Ingredients = Pizza.IngredientsDisponibles, Nom = "Végétarienne", Pate = Pizza.PatesDisponibles });
        //    listepizza.Add(new Pizza { Id = 4, Ingredients = Pizza.IngredientsDisponibles, Nom = "NoIdea", Pate = Pizza.PatesDisponibles });

        //    return listepizza;
        //}

        public List<Ingredient> GetListeIngredients()
        {
            List<Ingredient> listeIngredients = new List<Ingredient>();

            listeIngredients.Add(new Ingredient { Id = 1, Nom = "Mozzarella" });
            listeIngredients.Add(new Ingredient { Id = 2, Nom = "Jambon" });
            listeIngredients.Add(new Ingredient { Id = 3, Nom = "Tomate" });
            listeIngredients.Add(new Ingredient { Id = 4, Nom = "Oignon" });
            listeIngredients.Add(new Ingredient { Id = 5, Nom = "Cheddar" });
            listeIngredients.Add(new Ingredient { Id = 6, Nom = "Saumon" });
            listeIngredients.Add(new Ingredient { Id = 7, Nom = "Champignon" });
            listeIngredients.Add(new Ingredient { Id = 8, Nom = "Poulet" });

            return listeIngredients;
        }

        public List<Pate> GetPate()
        {
            List<Pate> listePates = new List<Pate>();

            listePates.Add(new Pate { Id = 1, Nom = "Pate fine, base crême" });
            listePates.Add(new Pate { Id = 2, Nom = "Pate fine, base tomate" });
            listePates.Add(new Pate { Id = 3, Nom = "Pate épaisse, base crême" });
            listePates.Add(new Pate { Id = 4, Nom = "Pate épaisse, base tomate" });

            return listePates;
        }
    }
}