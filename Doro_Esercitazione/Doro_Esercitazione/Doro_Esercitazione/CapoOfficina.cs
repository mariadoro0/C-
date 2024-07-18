using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
{
    /*
     * 5) CapoOfficina eredita da Meccanico con

metodi: Tredicesima che ridefinisce il metodo e restituisce il doppio dello stipendio più il 5% dell’importo di ogni ordine da gestire, ToString
    */
    internal class CapoOfficina : Meccanico
    {
        protected CapoOfficina(string nome, string cognome, double stipendio, TIPOLOGIA tipologia) : base(nome, cognome, stipendio, tipologia)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override double Tredicesima()
        {
            return base.Tredicesima();
        }
    }
}
