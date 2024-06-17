using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaccia
{
    internal interface InterfacciaGenerale : Interfaccia, Interfaccia2
    {
        public bool Metodo5(int numero);
    }
}
