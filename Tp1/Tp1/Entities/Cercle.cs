using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1.Entities
{
    public class Cercle : Forme
    {
        //Périmetre : (r*2) * π
        //Aire : R2 x π

        private int rayon;
        private double pi = Math.PI;

        public int Rayon { get => rayon; set => rayon = value; }
        public double Pi { get => pi; set => pi = value; }

        public override string ToString()
        {
            return string.Format("Un cercle a un rayon de : {0} et {1}",
                Rayon, base.ToString());
        }

        public override string AireCalcul()
        {
            Aire = (Rayon * 2) * Pi;
            return Aire.ToString();
        }

        public override string PerimetreCalcul()
        {
            Perimetre = (Rayon * Rayon) * Pi;
            return Perimetre.ToString();
        }
    }
}
