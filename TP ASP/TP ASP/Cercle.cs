using System;

namespace TP_ASP
{
    internal class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override double Aire => calculAire();
        public override double Perimetre => calculPerimetre();

        private double calculAire()
        {
            return Math.PI * Math.Pow(Rayon, 2);
        }

        private double calculPerimetre()
        {
            return 2 * Math.PI * Rayon;
        }

        public override string ToString()
        {
            return $"Cercle de rayon {Rayon}\n\r" + base.ToString();
        }
    }
}