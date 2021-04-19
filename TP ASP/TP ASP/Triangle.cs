using System;

namespace TP_ASP
{
    internal class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        private double calculAire()
        {
            double demiPerimetre = (double)calculPerimetre() / 2;
            return Math.Sqrt(demiPerimetre * (demiPerimetre - A) * (demiPerimetre - B) * (demiPerimetre - C));
        }

        private int calculPerimetre()
        {
            return A + B + C;
        }

        private void affichageCote()
        {
            Console.WriteLine($"Triangle de côté A = {A}, B = {B}, C = {C}");
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