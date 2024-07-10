using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneImmobili
{
    internal class Villa : Appartamento
    {
        public int Giardino { get; set; }

        public override string ToString()
        {
            return base.ToString()+$", MqGiardino= {Giardino}";
        }

        public override string StampaDettaglio()
        {
            return base.StampaDettaglio()+$"GIARDINO: {Giardino} metri quadri.";
        }
    }
}
