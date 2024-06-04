using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal class Cilindro:Solido
    {
        private double raggio;
        private double altezza;

        public Cilindro(double raggio, double altezza, Materiale materiale) : base(materiale)
        {
            this.raggio = raggio;
            this.altezza = altezza;
        }

        public override double Volume()
        {
            return Math.PI * Math.Pow(raggio, 2) * altezza;
        }

        public override string ToString()
        {
            return $"\tCilindo\t"+
                $"\nRaggio: {raggio} dm"+
                $", Altezza: {altezza} dm, "+base.ToString();
        }
    }

}
