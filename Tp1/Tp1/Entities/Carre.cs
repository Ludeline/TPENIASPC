using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1.Entities
{
    public class Carre : Forme

    {
        //Périmètre = 4 * Longueur
        //Aire = Longueur * Longueur
        private int longueur;


        public int Longueur { get => longueur; set => longueur = value; }



        public override string ToString()
        {
            return string.Format("Un carré a une longueur de : {0} et {1}" ,
                Longueur, base.ToString());
        }

        public override string AireCalcul()
        {
            Aire = Longueur * Longueur;
            return Aire.ToString();
        }

        public override string PerimetreCalcul()
        {
            Perimetre = 4 * Longueur;
            return Perimetre.ToString();
        }

    }
}
