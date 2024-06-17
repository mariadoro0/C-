using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atleti
{
    internal class Atleta : IAtleta
    { /* nome cognome numero disciplina */
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public int NumeroPettorina { get; set; }
        public string? Disciplina { get; set; } /*tennista nuotatore calciatore*/

        public string Corro()
        {
            return "Sto correndo!";
        }

        public string Salto()
        {
            return "Sto saltando!";
        }

        public override string ToString()
        {
            return $"{nameof(Nome)}={Nome}, " +
                $"{nameof(Cognome)}={Cognome}, " +
                $"{nameof(NumeroPettorina)}={NumeroPettorina.ToString()}, " +
                $"{nameof(Disciplina)}={Disciplina}";
        }
    }
}
