using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneMessaggi
{
    internal class Messaggio
    {
        public string Mittente { get; set; } = string.Empty;
        public string Destinatario { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public PRIORITY Priority { get; set; } = PRIORITY.NORMALE;


        public override string ToString()
        {
            return $"MITTENTE= {Mittente}, DESTINATARIO={Destinatario}, CONTENUTO DEL MESSAGGIO=\"{Text}\", DATA={Date.ToString()}, PRIORITA'={Priority.ToString()}";
        }
    }
}
