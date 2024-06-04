using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadrilateri
{
    internal class Rettangolo:Quadrilatero
    {

        // :base() --> riferimento al costruttore della super classe
    public Rettangolo(double Base, double Altezza):base(Base, Altezza, Base, Altezza){}

    public double Area()
        {
            return base.lato1 * base.lato2;
        }

    public double Diagonale()
        {
            return Math.Sqrt(Math.Pow(lato1,2)+Math.Pow(lato2,2)); 
        }

        public override string ToString()
        {
            return $"Base: {lato1}" +
                $", Altezza: {lato2}" +
                $", Perimetro: {Perimetro()}"+
                $", Area: {Area()}"+
                $", Diagonale: {Diagonale()}";
        }
    }
}
