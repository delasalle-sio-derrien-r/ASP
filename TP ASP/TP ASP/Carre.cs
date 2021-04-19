using System;

namespace TP_ASP
{
    internal class Carre : Forme
    {
        public int Longueur { get; set; }

        public override double Aire => calculAire();
        public override double Perimetre => calculPerimetre();

        private double calculAire()
        {
            return Longueur * Longueur;
        }

        private int calculPerimetre()
        {
            return Longueur * 4;
        }

        public override string ToString()
        {
            return $"Carré de côté {Longueur}\n\r" + base.ToString();
        }
    }
}
