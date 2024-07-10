using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneImmobili 
{
    internal class Box : Immobile
    {
        public int PostiAuto { get; set; }

        public override string ToString()
        {
            return base.ToString()+$", Posti auto={PostiAuto}";
        }

        public override string StampaDettaglio()
        {
            return base.StampaDettaglio()+$"POSTI AUTO: {PostiAuto}\n";
        }
    }
}
