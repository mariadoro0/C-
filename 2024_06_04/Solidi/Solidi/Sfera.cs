﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal class Sfera : Solido
    {
        private double raggio;
        public Sfera(double raggio, Materiale materiale) : base(materiale)
        {
            this.raggio = raggio;
        }

        public override string ToString()
        {
            return $"\tSfera\t"+
                $"\nRaggio: {raggio} dm, " + base.ToString();
        }

        public override double Volume()
        {
            return 4*Math.PI*Math.Pow(raggio,3)/3;
        }
    }
}
