using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpPizzaMonEssai.Entities
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public virtual Pate Pate { get; set; }
        public virtual List<Ingredients> Ingredients { get; set; } = new List<Ingredients>();
    }
}