using System;

namespace TP_ASP
{
    internal class Carre : Forme
    {
        public int Longueur { get; set; }

        private static double calculAire(int longueur)
        {
            return longueur * longueur;
        }

        private static int calculPerimetre(int longueur)
        {
            return longueur * 4;
        }

        private void affichageCote()
        {
            Console.WriteLine($"Carré de côté {Longueur}");
        }

        public override string ToString()
        {
            affichageCote();
            aire(calculAire(Longueur));
            perimetre(calculPerimetre(Longueur));
            return "";
        }
    }
}
