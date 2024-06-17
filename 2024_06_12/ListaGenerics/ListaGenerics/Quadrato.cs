using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureGeometriche
{
    internal class Quadrato
    {
        //attributi
        private double lato;


        //proprietà

        //getters e setters diventano un """metodo""" in questo modo, e si richiama solo Lato
        public double Lato
        {
            get { return lato; }
            set {
                if (value <= 0)
                    throw new Exception("Lato non valido.");
                lato = value;
            }
        }

        public override string ToString()
        {
            return $"Lato: {lato}"+
                $"\nPerimetro: {Perimetro():#.###}"+
                $"\nArea: {Area():#.###}"+
                $"\nDiagonale {Diagonale():#.###}";
        }

        //metodi
        public double Perimetro() { return lato*4; }
        public double Area() { return lato*lato; }
        public double Diagonale() { return lato*Math.Sqrt(2); }
    }
        
}
