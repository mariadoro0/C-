using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneMessaggi
{
    internal class MessaggiBiz
    {
        public List<Messaggio> archivio {  get; set; }

        public void aggiungiMessaggio(Messaggio m)
        {
            this.archivio.Add(m);
        }

        public int cercaMittente(Utente u)
        {
            for(int i = 0; i < archivio.Count; i++)
            {
                if (archivio[i].Mittente.Equals(u))
                {
                    return i;
                }
            }
            return -1;
        }
        
        public int cercaDestinatario(Utente u)
        {
            for (int i = 0; i < archivio.Count; i++)
            {
                if (archivio[i].Destinatario.Equals(u))
                {
                    return i;
                }
            }
            return -1;
        }
        
        public int contaPerData(DateTime date)
        {
            int counter = 0;
            foreach (var m in archivio)
            {
                if(DateTime.Compare(date,m.Date) <= 0)
                {
                    counter++;
                }
            }
            return counter;

        }

        public string StampaMessaggi()
        {
            string s = string.Empty;
            foreach(var line in archivio)
            {
                s = s+line+"\n";
            }

            return s;
            
        }

    }
}
