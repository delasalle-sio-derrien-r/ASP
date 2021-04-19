using System;

namespace TP_ASP
{
    public abstract class Forme
    {
        public abstract double Aire { get; }
        public abstract double Perimetre { get; }
        public override string ToString()
        {
            return $"Aire = {Aire}\n\rPerimetre = {Perimetre}\n\r";
        }

    }
}