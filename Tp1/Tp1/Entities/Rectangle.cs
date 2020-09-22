using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1.Entities
{
    public class Rectangle : Forme
    {

        private int largeur;
        private int longueur;


        public int Largeur { get => largeur; set => largeur = value; }
        public int Longueur { get => longueur; set => longueur = value; }



        public override string ToString()
        {
            //Le base.ToString() sert à appeler le ToString du Forme.cs
            return string.Format("Un rectangle a une longueur de : {0} et une largueur {1} et {2}", Largeur, Longueur, base.ToString());
        }

        public override string PerimetreCalcul()
        {
            Perimetre = 2 * (Longueur + Largeur);
            return Perimetre.ToString();
        }

        public override string AireCalcul()
        {
            Aire = Longueur * Largeur;
            return Aire.ToString();
        }
    }
}
