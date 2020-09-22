using MaPremiereApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaPremiereApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p1 = new Personne();
            p1.Age = 27;
            p1.Nom = "Fancy";
            p1.Prenom = "Elois";

            Console.WriteLine(p1);

            Personne p2 = new Personne { Age = 12, Nom = "Hello", Prenom = "Blah" };

            Console.WriteLine(p2);

            Personne p3 = new Personne("Hola", "Quetal", 65);

            Console.WriteLine(p3);
            Console.ReadKey();
        }
    }
}
