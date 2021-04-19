using System;

namespace TP_ASP
{
    internal class Cercle : Forme
    {
        public int Rayon { get; set; }

        private static double calculAire(int rayon)
        {
            return Math.PI * Math.Pow(rayon, 2);
        }

        private static double calculPerimetre(int rayon)
        {
            return 2 * Math.PI * rayon;
        }

        private void affichageCote()
        {
            Console.WriteLine($"Cercle de rayon {Rayon}");
        }

        public override string ToString()
        {
            affichageCote();
            aire(calculAire(Rayon));
            perimetre(calculPerimetre(Rayon));
            return "";
        }
    }
}