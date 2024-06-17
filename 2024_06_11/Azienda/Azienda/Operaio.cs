using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    internal class Operaio : Dipendente
    {
        public TipoMansioneOperaio mansione { get; set; }


        public override double Stipendio()
        {
            var bonus = 0;
            if (mansione == TipoMansioneOperaio.MANUTENTORE) { bonus = 230; }
            else { bonus = 185; }
            return base.Stipendio() + bonus;    

            /*
            if (this.mansione == TipoMansioneOperaio.MANUTENTORE)
            {
                return base.Stipendio()+230;
            } else { return base.Stipendio() + 185; }
            */
        }

        public override string ToString()
        {
            return $"{{{base.ToString()}, {nameof(mansione)}={mansione.ToString()}}}";
        }
    }

    
}
