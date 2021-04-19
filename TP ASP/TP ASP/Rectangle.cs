using System;

namespace TP_ASP
{
    internal class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }

        private double calculAire()
        {
            return Longueur * Largeur;
        }

        private int calculPerimetre()
        {
            return Longueur * 2 + Largeur * 2;
        }

        private void affichageCote()
        {
            Console.WriteLine($"Rectangle de longueur = {Longueur} et largeur {Largeur}");
        }

        public override string ToString()
        {
            affichageCote();
            aire(calculAire());
            perimetre(calculPerimetre());
            return "";
        }
    }
}