using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_LINQ.BO;

namespace TP_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialiserDatas();
            affichage();
        }
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

        private static void affichage()
        {
            var prenoms = ListeAuteurs.Where(a => a.Nom.StartsWith("G")).Select(p => p.Prenom);
            foreach (var prenom in prenoms)
            {
                Console.WriteLine(prenom);
            }
            Console.WriteLine();


            var auteur = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(x => x.Count()).FirstOrDefault().Key;

            Console.WriteLine($"{auteur.Prenom} {auteur.Nom}");
            Console.WriteLine();

            var pageMoyenParLivreParAuteur = ListeLivres.GroupBy(x => x.Auteur);
            foreach (var livre in pageMoyenParLivreParAuteur)
            {
                Console.WriteLine($"{livre.Key.Prenom} {livre.Key.Nom} {livre.Average(x => x.NbPages)}");
            }
            Console.WriteLine();

            var livrePlusDePage = ListeLivres.OrderByDescending(x => x.NbPages).First();
            Console.WriteLine(livrePlusDePage.Titre);
            Console.WriteLine();

            var gainMoyen = ListeAuteurs.Average(x => x.Factures.Sum(y => y.Montant));
            Console.WriteLine(gainMoyen);
            Console.WriteLine();

            var livresParAuteur = ListeLivres.GroupBy(x => x.Auteur);
            foreach (var livres in livresParAuteur)
            {
                Console.WriteLine($"{livres.Key.Prenom} {livres.Key.Nom}");
                foreach (var livre in livres)
                {
                    Console.WriteLine($"{livre.Titre}");
                }
            }
            Console.WriteLine();

            var livresTries = ListeLivres.Select(x => x.Titre).OrderBy(y => y).ToList();
            foreach (var livre in livresTries)
            {
                Console.WriteLine($"{livre}");
            }
            Console.WriteLine();

            var moyennePagesLivres = ListeLivres.Average(x => x.NbPages);
            var livresPagesSuperieuresMoyenne = ListeLivres.Where(x => x.NbPages > moyennePagesLivres);
            foreach (var livre in livresPagesSuperieuresMoyenne)
            {
                Console.WriteLine($"{livre.Titre}");
            }
            Console.WriteLine();

            var auteurMoinsDeLivresEcrit = ListeAuteurs.OrderBy(x => ListeLivres.Count(y => y.Auteur == x)).FirstOrDefault();
            Console.WriteLine($"{auteurMoinsDeLivresEcrit.Prenom} {auteurMoinsDeLivresEcrit.Nom}");
            Console.ReadKey();
            Console.ReadLine();
        }
    }
}
