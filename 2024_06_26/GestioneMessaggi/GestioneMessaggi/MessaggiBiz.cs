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
            archivio.Add(m);
        }

        public List<Messaggio> cercaMessaggiMittente(string nome)
        {
            var lista = new List<Messaggio>();
            foreach(var m in archivio) 
            {
                if (m.Mittente.Equals(nome))
                {
                    lista.Add(m);
                }
            }
            return lista;
        }
        public List<Messaggio> cercaMessaggiDestinatario(string nome)
        {
            var lista = new List<Messaggio>();
            foreach (var m in archivio)
            {
                if (m.Destinatario.Equals(nome))
                {
                    lista.Add(m);
                }
            }
            return lista;
        }

        public List<Messaggio> cercaMessaggiData(DateTime data)
        {
            var lista = new List<Messaggio>();
            foreach (var m in archivio)
            {
                if (m.Date>data)
                {
                    lista.Add(m);
                }
            }
            return lista;
        }

        public int contaPerData(DateTime date)
        {
            return cercaMessaggiData(date).Count;
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
