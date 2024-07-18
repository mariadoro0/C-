using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
{
    /*
     * 6) Prodotto che contiene come

proprietà: Codice, Prodotto, Descrizione, Prezzo
metodi: ToString
    */
    internal class Prodotto
    {
        public string Codice { get; set; }
        public string Denominazione { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }

        public Prodotto(string codice, string denominazione, string descrizione, double prezzo)
        {
            Codice = codice;
            Denominazione = denominazione;
            Descrizione = descrizione;
            Prezzo = prezzo;
        }

        public override string ToString()
        {
            return $"{{{nameof(Codice)}={Codice}, {nameof(Denominazione)}={Denominazione}, {nameof(Descrizione)}={Descrizione}, {nameof(Prezzo)}={Prezzo.ToString()}}}";
        }
    }


}
