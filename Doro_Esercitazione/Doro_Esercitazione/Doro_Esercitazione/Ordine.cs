using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
{
    /*
     * 7) Ordine (classe che impedisce l’ereditarietà) che contiene come

proprietà: CodiceOrdine di tipo alfanumerico a lunghezza 8 caratteri fissi e univoco e generato automaticamente, la Data, ElencoProdotti ovvero la lista di prodotti assegnati all'ordine, Venditore di tipo Venditore
metodi: NumeroProdotti che restituisce la quantità totale di prodotti ordinati, Totale il costo complessivo, StampaOrdine che è un metodo per stampare l’elenco dettagliato dell’ordine su file txt con nome file codice ordine,
    che deve essere salvato nella cartella file presente all'interno del progetto a pari livello del main, dove sono presenti tutti i dati dell'ordine e per ogni prodotto su singola riga è presente il codice prodotto, 
    nome del prodotto, quantità ordinata, prezzo unitario e subtotale. Alla fine di questo elenco è presente il totale dell'ordine. ToString 

*/

    internal sealed class Ordine
    {
        static List<string> codici;
        public string CodiceOrdine
        {
            get { return this.CodiceOrdine; }
            set { this.CodiceOrdine = SetCodiceOrdine(); }
        }
        public DateTime Data { get; set; }
        public List<Acquisto> ElencoProdotti { get; set; }
        public Venditore Venditore { get; set; }

        public Ordine(DateTime data, List<Acquisto> elencoProdotti, Venditore venditore)
        {
            Data = data;
            ElencoProdotti = elencoProdotti;
            Venditore = venditore;
        }

        private string SetCodiceOrdine()
        {
            string strOrdine = string.Empty;
            Random r = new Random();
            bool flag = true;
            while (flag) {
                for (int i = 0; i < 8; i++) {
                    strOrdine += r.Next(10);
                }
                foreach (string str in codici) {
                    if (str.Equals(strOrdine)){
                        flag = true;
                    }
                    else {
                        codici.Append(strOrdine);
                        flag = false;
                        break;
                    }
                }
            }
            return strOrdine;

        }


       


        public int numProdotti()
        {
            return ElencoProdotti.Count;
        }

        public double Totale()
        {
            double tot = 0;
            foreach(var item in ElencoProdotti)
            {
                tot = tot + item.Subtotale();
            }
            return tot;
        }

        public Prodotto FindProdotto(string codice)
        {
            foreach(var item in ElencoProdotti)
            {
                if(item.Prodotto.Codice == codice)
                {
                    return item.Prodotto;
                }
            } return null;
        }


        public void StampaOrdine()
        {
            string stampa = $"""
                *******************ORDINE {CodiceOrdine} *****************
                *   PRODOTTO                QUANTITA'           PREZZO    *
                """;
            foreach (var item in ElencoProdotti)
            {
                stampa += $"*{item.Prodotto.Denominazione}          {item.Quantita}     {item.Subtotale}*\n";
            }
            stampa += $"""
                 ********************************************************
                 *   TOTALE                                 {Totale()} *
                 ********************************************************
                 """;

            string path = $"\\Doro_Esercitazione\\Doro_Esercitazione\\Doro_Esercitazione\\file\\{CodiceOrdine}.txt";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(stampa);
            sw.Close();

        }



    }
}
