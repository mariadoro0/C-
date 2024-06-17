using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    internal class DipendentiBiz
    {
        public Dipendente[] dipendenti { get; set; }

        public string StampaElenco(Dipendente[] elenco)
        {
            return string.Join("\n", elenco.ToString());
        }

        public int ContaAmministrativi()
        {
            int conta = 0;
            foreach (var item in dipendenti)
            {
                if (item is Amministrativo)
                {
                    conta++;
                }
            }
            return conta;
        }

        public Amministrativo[] amministrativi()
        {
            Amministrativo[] lista = new Amministrativo[ContaAmministrativi()];
            string txt = string.Empty;
            int k = 0;
            for (int i = 0; i < lista.Length; i++)
            {
                if (dipendenti[i] is Amministrativo)
                {
                    lista[k++] = (Amministrativo)dipendenti[i];
                }
            }
            return lista;
        }

        public string StampaOperai()
        {
            string txt = string.Empty;
            for (int i = 0; i < dipendenti.Length; i++)
            {
                if (dipendenti[i] is Operaio)
                {
                    txt += (txt.Length != 0 ? "\n" : "") + dipendenti[i].ToString();
                }
            }
            return txt;
        }

        public string StampaOperaiSpec()
        {
            string txt = string.Empty;
            for (int i = 0; i < dipendenti.Length; i++)
            {
                if (dipendenti[i] is OperaioSpecializzato)
                {
                    txt += (txt.Length != 0 ? "\n" : "") + dipendenti[i].ToString();
                }
            }
            return txt;
        }

        public string StampaStipendio2k()
        {
            string txt = string.Empty;
            foreach(Dipendente d in dipendenti)
            {
                if (d is Operaio && d.Stipendio() >= 2000)
                {
                    txt += (txt.Length != 0 ? "\n" : "") + d.ToString();
                }
            }
            return txt;
        }

        public string StampaManutentori()
        {
            string txt = string.Empty;
            foreach (Dipendente d in dipendenti)
            {
                if (d is Operaio operaio && operaio.mansione == TipoMansioneOperaio.MANUTENTORE)
                {
                    txt += (txt.Length != 0 ? "\n" : "") + d.ToString();
                }
            }
            return txt;
        }

        public string StampaSchedaDirettore()
        {
            string txt = string.Empty;
            foreach (Dipendente d in dipendenti)
            {
                if (d is Amministrativo a && a.mansione == TipoMansioneAmministrativo.DIRETTORE)
                {
                    txt+= d.ToString();
                }
            }
            return txt;
        }

    }
}
