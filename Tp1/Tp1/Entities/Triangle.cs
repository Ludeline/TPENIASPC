using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tp1.Entities
{
    class Triangle : Forme
    {
        //Aire triangle :  A = (B × h) : 2.
        //Périmètre : AB + BC + CA.

        private int a;
        private int b;
        private int c;


        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public int C { get => c; set => c = value; }

        public override string ToString()
        {
            return string.Format("Un triangle a trois côtés de : {0} {1} {2} et {3}",
                A, B, C, base.ToString());
        }

        public override string AireCalcul()
        {
            double perimetreParDeux = (A + B + C) / 2;
            Aire = Math.Sqrt(perimetreParDeux * (perimetreParDeux - a) * (perimetreParDeux - b) * (perimetreParDeux - c));
            return Aire.ToString();
        }

        public override string PerimetreCalcul()
        {
            Perimetre = A + B + C;
            return Perimetre.ToString();
        }
    }
}
