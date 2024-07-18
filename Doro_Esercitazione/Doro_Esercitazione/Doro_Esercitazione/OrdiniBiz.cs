using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
{
    /*8) OrdiniBiz che contiene

proprietà: Ordini ovvero una lista di tipo Ordine.
metodi: AggiungiOrdine(Ordine ordine, int index) 
    che inserisce un ordine nella lista alla posizione index, 
    NumeroOrdini che restituisce il numero di ordini che sono presenti nella lista;
    TotaleFatturato che restituisce la somma dei totali degli ordini relativi al corrente anno in corso
    */
    internal class OrdiniBiz
    {
        public List<Ordine> Ordini { get; set; }


        public void AggiungiOrdine(Ordine ordine, int index)
        {
            Ordini.Insert(index, ordine);
        }

        public int NumeroOrdini()
        {
            return Ordini.Count; 
        }

        public double TotaleFatturato()
        {
            double fatturato = 0;
            foreach (Ordine ordine in Ordini)
            {
                if(ordine.Data.Year == DateTime.Now.Year)
                {
                    fatturato += ordine.Totale();
                }
            }
            return fatturato;
        }

        public List<Ordine> CercaByVenditore(Venditore venditore)
        {
            var lista = new List<Ordine>();
            foreach (Ordine ordine in Ordini)
            {
                if(ordine.Venditore == venditore)
                {
                    lista.Add(ordine);
                }
            }
            return lista;
        }


        public Ordine CercaOrdineByCodice(string codice)
        {
            foreach (Ordine ordine in Ordini)
            {
                if(ordine.CodiceOrdine == codice)
                {
                    return ordine;
                }
            }
            return null;
        }

        public List<Ordine> FindOrdiniProdotto(string codice)
        {
            bool flag = false;
            var lista = new List<Ordine>();
            foreach(Ordine ordine in Ordini)
            {
                foreach(var acquisto in ordine.ElencoProdotti)
                {
                    if(acquisto.Prodotto.Codice == codice)
                    {
                        flag = true;
                            break;
                    }
                    if (flag)
                    {
                        lista.Add(ordine);
                    }
                }
            }
            return lista;
        }
    }
}
