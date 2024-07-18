using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 1) Persona è una classe astratta con

proprietà: Nome, Cognome, Stipendio
metodi: Tredicesima, ToString
*/

namespace Doro_Esercitazione
{
    internal abstract class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public double Stipendio { get; set; }


        public abstract double Tredicesima();

        public override string ToString()
        {
            return $"{nameof(Nome)}={Nome}, {nameof(Cognome)}={Cognome}, {nameof(Stipendio)}={Stipendio.ToString()}";
        }
    }
}
