using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
{
    /*
     * 9) VenditoriBiz che contiene
proprietà: Venditori che serve a contenere un elenco di venditori di cui uno è responsabile
metodi: AggiungiVenditore(Venditore venditore) che aggiunge in coda alla lista un venditore, 
    RestituisciVenditore(int index) che restituisce il venditore presente nella lista alla posizione index, CancellaVenditore(int index) che rimuove il venditore presente nella lista alla posizione index.
    */
    internal class VenditoriBiz
    {
        public List<Venditore> Venditori { get; set; }

        public void AggiungiVenditore(Venditore venditore)
        {
            Venditori.Add(venditore);
        }

        public Venditore RestituisciVenditore(int index)
        {
            return Venditori[index]; 
        }

        public void CancellaVenditore(int index)
        {
            Venditori.RemoveAt(index);
        }

        public Venditore FindByCognome(string cognome)
        {
            foreach (var item in Venditori)
            {
                if (item.Cognome == cognome)
                    return item;
            }
            return null;
        }
    }
}
