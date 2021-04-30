using System;

namespace TP_ASP
{
    internal class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }

        public override double Aire => calculAire();
        public override double Perimetre => calculPerimetre();

        private double calculAire()
        {
            return Longueur * Largeur;
        }

        private int calculPerimetre()
        {
            return Longueur * 2 + Largeur * 2;
        }

        public override string ToString()
        {
            return $"Rectangle de longueur = {Longueur} et largeur {Largeur}\n\r" + base.ToString();
        }
    }
}