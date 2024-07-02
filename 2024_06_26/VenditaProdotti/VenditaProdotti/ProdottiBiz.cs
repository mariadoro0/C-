using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace VenditaProdotti
{
    internal class ProdottiBiz
    {
        public Prodotto[] prodotti {  get; set; }
        public string StampaElenco(Prodotto[] prodotti)
        {
            return string.Join("\n", prodotti.ToString());
        }

        public ProdottoAlimentare[] alimentari()
        {
            int k = 0;
            ProdottoAlimentare[] alimentari = new ProdottoAlimentare[prodotti.Length];
            for (int i = 0; i < prodotti.Length; i++)
            {
                if (prodotti[i] is ProdottoAlimentare)
                {
                    alimentari[k++] = (ProdottoAlimentare)prodotti[i];
                }
            }
            return alimentari;
            
        }

        public ProdottoNonAlimentare[] nonAlimentari()
        {
            int k = 0;
            ProdottoNonAlimentare[] nonAlimentari = new ProdottoNonAlimentare[prodotti.Length];
            for (int i = 0;i < prodotti.Length; i++)
            {
                if (prodotti[i] is ProdottoNonAlimentare)
                {
                    nonAlimentari[k++] = (ProdottoNonAlimentare)(prodotti[i]);
                }
            }
            return nonAlimentari;
        }

        public ProdottoAlimentare[] inScadenza()
        {
            int k = 0;
            var elenco = alimentari();
            var day = new TimeSpan(10);
            ProdottoAlimentare[] inScadenza = new ProdottoAlimentare[elenco.Length];
            for (int i = 0; i < elenco.Length; i++)
            {
                if (DateTime.Today.Subtract(elenco[i].Expiration) <= day)
                {
                    inScadenza[k++] = elenco[i];
                }
            }
            return inScadenza;
        }

        public string materiePrime(ProdottoNonAlimentare p)
        {
            string txt = string.Empty;
            foreach(var line in p.MadeOf)
            {
                txt += $"\n{line.Percentage}% di {line.Materiale}";
            }
            return txt;
        }

        
        
    }
}
