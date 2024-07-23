using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProvaITS
{
    internal class EsamiBiz
    {
        public List<Esame> Esami { get; set; }
        
        public string StampaElenco() => string.Join("\n", Esami);

        public double MediaEsami() => Esami.Average(x => x.VotoFinale());
        public List<Esame> Graduatoria() => Esami.OrderByDescending(x => x.VotoFinale()).ToList();
    }
}
