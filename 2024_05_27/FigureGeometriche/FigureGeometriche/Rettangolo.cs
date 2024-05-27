using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureGeometriche
{
    internal class Rettangolo
    {

        //gli attributi si possono nella amggior parte dei casi definire in questo modo automatico
        // più conveniente
        // scrivere prop e premere Tab

        public double Base { get; set; }

        public double Altezza { get; set; }

        public override string ToString()
        {
            return $"Base: {Base}"+ 
                $"\nAltezza: {Altezza}"+ 
                $"\nDiametro: {Perimetro():#.###}"+
                $"\nArea: {Area():#.###}"+
                $"\nDiagonale: {Diagonale():#.###}";
        }

        public double Perimetro() { return Base * 2 + Altezza * 2; }
        public double Area() { return Base * Altezza; }
        public double Diagonale() { return (Math.Sqrt(Math.Pow(Base,2)+Math.Pow(Altezza,2))); }
    }

}
