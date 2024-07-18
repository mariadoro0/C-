using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
{   /*
     * 4) ResponsabileVenditori eredita da Venditore con

metodi:  Tredicesima che restituisce il doppio dello stipendio più un bonus del 15% della tariffa giornaliera di ogni venditore di cui è responsabile, ToString
    */
    internal class ResponsabileVenditori : Venditore
    {
        public ResponsabileVenditori(string nome, string cognome, double stipendio, SETTORE settore) : base(nome, cognome, stipendio, settore)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override double Tredicesima()
        {

            return base.Tredicesima() /*****/;
        }
    }
}
