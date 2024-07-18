using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
{
    /*classe acquisto da inserire nell'ordine: registra un prodotto e la quantità acquistata e ha metodi per calcolarne il subtotale*/
    internal class Acquisto
    {
        public Prodotto Prodotto { get; set; }
        public int Quantita { get; set; }

        public Acquisto(Prodotto prodotto, int quantita)
        {
            Prodotto = prodotto;
            Quantita = quantita;
        }

        public override string ToString()
        {
            return $"{nameof(Prodotto)}={Prodotto}, {nameof(Quantita)}={Quantita.ToString()}";
        }

        public double Subtotale()
        {
            return Prodotto.Prezzo * Quantita;
        }
    }
}
