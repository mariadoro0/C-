using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneMessaggi
{
    internal class Messaggio
    {
        public Utente Mittente { get; set; }
        public Utente Destinatario { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public PRIORITY Priority { get; set; }


        public override string ToString()
        {
            return $"MITTENTE: {{{Mittente}}}, DESTINATARIO: {{{Destinatario}}}, CONTENUTO DEL MESSAGGIO=\"{Text}\", DATA={Date.ToString()}, PRIORITA'={Priority.ToString()}";
        }
    }
}
