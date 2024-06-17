using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    internal class OperaioSpecializzato : Operaio
    {
        public int nMissioni { get; set; }
        public double indennita { get; set; }


        public override double Stipendio()
        {
            return base.Stipendio()+(nMissioni*indennita);
        }

        public override string ToString()
        {
            return $"{{{base.ToString()}, Numero missioni={nMissioni}, Indennità={indennita}";
        }
    }

    
}
