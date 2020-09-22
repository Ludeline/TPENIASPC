using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1.Entities
{
    public abstract class Forme
    {

        private double aire;
        private double perimetre;

        public double Aire { get => aire; set => aire = value; }
        public double Perimetre { get => perimetre; set => perimetre = value; }

        public abstract string AireCalcul();
        public abstract string PerimetreCalcul();

        public override string ToString()
        {
            return string.Format("Une aire de : {0} et Un périmètre de : {1}", AireCalcul(), PerimetreCalcul());
        }
    }
}
