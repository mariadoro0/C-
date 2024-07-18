using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
{
    internal class MeccaniciBiz
    {
        public List<Meccanico> Meccanici { get; set; }

        public void AggiungiMeccanico(Meccanico meccanico)
        {
            Meccanici.Add(meccanico);
        }

        public Meccanico RestituisciMeccanico(int index)
        {
            return Meccanici[index];
        }

        public void CancellaMeccanico(int index)
        {
            Meccanici.RemoveAt(index);
        }
    }
}

