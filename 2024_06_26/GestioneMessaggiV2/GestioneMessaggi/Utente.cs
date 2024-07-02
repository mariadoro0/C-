using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneMessaggi
{
    internal class Utente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }



        public override string ToString()
        {
            return $"{nameof(Nome)}={Nome} {nameof(Cognome)}={Cognome}";
        }
    }
}
