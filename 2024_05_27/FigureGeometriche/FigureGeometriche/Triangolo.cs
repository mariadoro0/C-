using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureGeometriche
{
    internal class Triangolo
    {
        public double Lato1 { get; set; }
        public double Lato2 { get; set; }
        public double Lato3 { get; set; }

        public Triangolo()
        {
        }

        public Triangolo(double lato1, double lato2, double lato3)
        {
            Lato1 = lato1;
            Lato2 = lato2;
            Lato3 = lato3;
        }

        public Triangolo(Punto punto1, Punto punto2, Punto punto3)
        {
            Lato1 = punto1.Distanza(punto2);
            Lato2 = punto2.Distanza(punto3);
            Lato3 = punto3.Distanza(punto1);
        }

        public double Perimetro() { return Lato1 + Lato2 + Lato3; }
        public double Area() { //formula di erone
            double sp = Perimetro()/2;
            return Math.Sqrt(sp*(sp-Lato1)*(sp-Lato2)*(sp-Lato3)); }
        public string Tipo()
        {
            if (Lato1 == Lato2 && Lato1 == Lato3) { return "Equilatero"; }
            else if (Lato1 == Lato2 || Lato1 == Lato3 || Lato2 == Lato3) { return "Isoscele"; }
            else { return "Scaleno"; }
        }

        public bool IsCostruibile()
        {
            return Lato1 + Lato2 > Lato3 
                && Lato1 + Lato3 > Lato2 
                && Lato2 + Lato3 > Lato1;
        }

        public override string ToString()
        {
            if (!IsCostruibile())
                return "Con i lati forniti non è possibile costruire un triangolo";
            return 
                    $"{nameof(Lato1)}={Lato1.ToString()}" +
                    $"\n{nameof(Lato2)}={Lato2.ToString()}" +
                    $"\n{nameof(Lato3)}={Lato3.ToString()}" +
                    $"\nPerimetro: {Perimetro():#.###}" +
                    $"\nArea: {Area():#.###}" +
                    $"\nTipo: {Tipo():#.###}";
        }


        }
    }
