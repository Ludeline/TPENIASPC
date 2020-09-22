using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppWebAvecBdd.Models
{
    public class Class1
    {
        int id;
        string nom;
        string prenom;
        int age;

        public Class1(int id, string nom, string prenom, int age)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int Age { get => age; set => age = value; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} ", this.Nom, this.Prenom, this.Age);
        }
    }
}