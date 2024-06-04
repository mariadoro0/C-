using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal class Cubo:Solido
    {
        private double lato;

        public Cubo(double lato, Materiale materiale) : base(materiale)
        {
            this.lato = lato;
        }

        public override double Volume()
        {
            return Math.Pow(lato,3);
        }

        public override string ToString()
        {
            return $"\tCubo\t"+
                $"\nLato: {lato} dm, "+base.ToString();
        }
    }
}
