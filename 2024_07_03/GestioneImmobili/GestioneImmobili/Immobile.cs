using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneImmobili
{
    internal class Immobile
    {
        public string Id { get; set; }
        public string Indirizzo { get; set; }
        public string Cap { get; set; }
        public string Citta { get; set; }
        public int Metratura { get; set; }
        public double Proposta { get; set; }

        public override string ToString()
        {
            return $"Tipo={GetType()}, {nameof(Id)}={Id}, {nameof(Indirizzo)}={Indirizzo}, {nameof(Cap)}={Cap}, {nameof(Citta)}={Citta}, {nameof(Metratura)}={Metratura.ToString()}, {nameof(Proposta)}={Proposta.ToString()}";
        }

        public virtual string StampaDettaglio()
        {
            return $"\n=======IMMOBILE {Id}=========\n" +
                $"INDIRIZZO: {Indirizzo}\n" +
                $"CAP: {Cap}\n" +
                $"CITTA': {Citta}\n" +
                $"SUPERFICIE: {Metratura} metri quadri.\n" +
                $"PROPOSTA: {Proposta} euro.\n";
        }
    }


}
