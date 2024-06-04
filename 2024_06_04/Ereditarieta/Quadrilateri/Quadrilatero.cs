using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadrilateri
{
    internal class Quadrilatero
    {
        protected double lato1;
        protected double lato2;
        protected double lato3;
        protected double lato4;

        public double Lato1 { get; set; }
        public double Lato2 { get; set; }
        public double Lato3 { get; set; }
        public double Lato4 { get; set; }



        public Quadrilatero(double lato1, double lato2, double lato3, double lato4)
        {
            this.lato1 = lato1;
            this.lato2 = lato2;
            this.lato3 = lato3;
            this.lato4 = lato4;
        }

        public double Perimetro()
        {
            return lato1 + lato2 + lato3 + lato4;
        }

        public override string ToString()
        {
            return $"Lato 1: {lato1}" +
                $", Lato2: {lato2}" +
                $", Lato3: {lato3}" +
                $", Lato4: {lato4}" +
                $", Perimetro: {Perimetro()}";
        }


    }


}
