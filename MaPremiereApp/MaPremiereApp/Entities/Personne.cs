using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaPremiereApp.Entities
{
    class Personne
    {
        private static int globalId = 0;
        private int id;
        private String prenom;
        private String nom;
        private int age;

        //Le this fait la même chose que super dans Java
        public Personne(string prenom, string nom, int age) : this()
        {
            this.prenom = prenom;
            this.nom = nom;
            this.age = age;
        }

        public String Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        //Alt + entrée sur l'attribut revient à faire propfull
        public string Nom { get => nom; set => nom = value; }
        public int Age { get => age; set => age = value; }
        public int Id { get => id; }

        public Personne()
        {
            globalId++;
            id = globalId;
        }

        public override string ToString()
        {
            //Le String Format va faciliter l'ajout ou supprission d'attributs
            return String.Format("{0} {1} {2} {3}" , this.Id , this.Prenom , this.Nom , this.Age);
        }
    }
}
