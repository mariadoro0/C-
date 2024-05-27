using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace FigureGeometriche
{
    internal class Punto
    {
        //il punto di domanda indica che potrebbe essere Null
        public string? Etichetta { get; set; }
        public double X { get; set; }
        public double Y { get; set; }


        //overloading: creare metodi e costruttori con nomi uguali ma firma diversa
        public Punto(string etichetta, double x, double y)
        {
            Etichetta = etichetta;
            X = x;
            Y = y;
        }

        public Punto(double x, double y)
        {
            X = x;
            Y = y;
        }



        public double Distanza(Punto punto)
        {
            return Math.Sqrt(Math.Pow(X - punto.X, 2) + Math.Pow(Y - punto.Y, 2));
        }
        //overloading: se non si passano parametri si calcola la distanza dall'origine
        public double Distanza()
        {
            // metodo per calcolare la distanza dall'origine degli assi
            return Distanza(new Punto(0, 0));
        }

        public override string ToString()
        {
            return $"Etichetta={Etichetta}, X={X}, Y={Y}+" +
                $"\nDistanza dall'origine: {Distanza()}";
        }

        public string Stampa()      //seve stampare P(x,y) o (x,y) in base a come è stato inizializzato il punto
        {
            return $"{Etichetta}({X},{Y})";
        }
    }
}
