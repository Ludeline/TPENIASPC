using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2Test2.Entities;

namespace Tp2Test2
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
        static void Main(string[] args)
        {
            InitialiserDatas();
            Console.WriteLine("Test du coucou");

            //Afficher la liste des prenoms des auteurs dont le nom startWith G
            Console.WriteLine("Afficher la liste des prenoms des auteurs dont le nom startWith G ======================================================");
            foreach(var item in ListeAuteurs.Where(nomG => nomG.Nom.StartsWith("G")))
            {
                Console.WriteLine(item.Prenom);
            }
            Console.WriteLine("======================================================");

            //Afficher l'auteur ayant écrit le plus de livres
            Console.WriteLine("Afficher l'auteur ayant écrit le plus de livres ======================================================");
            var aha = ListeLivres.GroupBy(x => x.Auteur).OrderByDescending(ob => ob.Count()).First().Key;
            Console.WriteLine(aha.Prenom + " " + aha.Nom);
            Console.WriteLine("======================================================");

            //Afficher le nb moyen de pages par livre par auteur
            Console.WriteLine("Afficher le nb moyen de pages par livre par auteur ======================================================");
            foreach(var moyenne in ListeLivres.GroupBy(l => l.Auteur))
            {

                Console.WriteLine(moyenne.Key.Nom + moyenne.Key.Prenom + moyenne.Average(l => l.NbPages));
            }
            Console.WriteLine("======================================================");

            //Afficher le titre du livre avec le plus de pages
            Console.WriteLine("Afficher le titre du livre avec le plus de pages ======================================================");
            var livreuh = ListeLivres.OrderBy(l => l.NbPages).First();
                Console.WriteLine(livreuh.Titre);
            Console.WriteLine("======================================================");

            //Moyenne des factures par auteurs



            //Afficher auteurs + liste de leurs livres
            Console.WriteLine("Afficher auteurs + liste de leurs livres ======================================================");
            foreach (var item in ListeLivres.GroupBy(livresAuteurs => livresAuteurs.Auteur))
            {
                Console.WriteLine(item.Key.Prenom);
                Console.WriteLine(item.Key.Nom);
                foreach(var livre in item)
                {
                    Console.WriteLine("Livre : " + livre.Titre);
                }
                Console.WriteLine("________________________");
            }
            Console.WriteLine("======================================================");

            //Liste de tous les livres triés par ordre alphabétique
            Console.WriteLine("Liste de tous les livres triés par ordre alphabétique ======================================================");
            foreach(var livres in ListeLivres.Select(l => l.Titre).OrderBy(o=> o.Count()))
            {
                Console.WriteLine(livres);
            }
            Console.WriteLine("======================================================");


            //Liste des livres dont le nb est supérieur à la moyenne
            Console.WriteLine("Liste des livres dont le nb est supérieur à la moyenne ======================================================");
                var moyenneNbPage = ListeLivres.Average(l => l.NbPages);
                var nb = ListeLivres.Where(n => n.NbPages >= moyenneNbPage);
                foreach(var damnedMoyenne in nb)
            {
                Console.WriteLine("Moyenne : " + moyenneNbPage);
                Console.WriteLine(damnedMoyenne.Titre + " et leur nb de pages à l'appui : " + damnedMoyenne.NbPages);
            }
            Console.WriteLine("======================================================");

            //Auteur ayant écrit le moins de livres
            Console.WriteLine("Auteur ayant écrit le moins de livres =====================================================");
            var bleu = ListeLivres.GroupBy(l => l.Auteur).OrderBy(o => o.Count()).First();
            Console.WriteLine(bleu.Key.Nom + " " + bleu.Key.Prenom);
            Console.WriteLine("==========================================================================================");
            Console.ReadKey();
        }
    }
}
