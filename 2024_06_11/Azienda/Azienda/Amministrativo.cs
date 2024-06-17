using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    internal class Amministrativo : Dipendente
    {
        public TipoMansioneAmministrativo mansione { get; set; }

        

        public override string ToString()
        {
            return $"{{{base.ToString()}, {nameof(mansione)}={mansione.ToString()}}}";
        }

        public override double Stipendio()
        {
            var bonus = 0;
            switch (mansione)
            {
                case TipoMansioneAmministrativo.CONTABILE:
                    bonus = 150; break;
                case TipoMansioneAmministrativo.HR:
                    bonus = 75; break;
                case TipoMansioneAmministrativo.DIRETTORE:
                    bonus = 250; break;
            }
            return base.Stipendio() + bonus;



           /* if (this.mansione == TipoMansioneAmministrativo.CONTABILE)
            {
                return base.Stipendio() + 150 ;

            } 
            else if (this.mansione == TipoMansioneAmministrativo.HR)
            {
                return base.Stipendio() + 75;
            }
            else
            {
                return base.Stipendio() + 250;
            }*/
        }

    }
}
