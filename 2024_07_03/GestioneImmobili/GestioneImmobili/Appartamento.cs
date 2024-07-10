using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneImmobili
{
    internal class Appartamento : Immobile
    {
        public int NumVani { get; set; }
        public int NumBagni { get; set; }

        public override string ToString()
        {
            return base.ToString()+$", NumeroVani= {NumVani}, NumeroBagni= {NumBagni}" ;
        }

        public override string StampaDettaglio()
        {
            return base.StampaDettaglio()+$"NUMERO VANI: {NumVani}\n"+$"NUMERO BAGNI: {NumBagni}\n" ;
        }
    }
}
