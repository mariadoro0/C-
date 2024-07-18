using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
{ /*
   * 3) Meccanico eredita da Persona con

proprietà: Tipologia che descrive il tipo di settore a cui fa capo: Carrozzeria o Meccanica
metodi: Tredicesima che restituisce il 93% in più dello stipendio, Equals, ToString
    */
    internal class Meccanico : Persona, IEquatable<Meccanico>
    {
        public TIPOLOGIA Tipologia { get; set; }

        

        public Meccanico(string nome, string cognome, double stipendio, TIPOLOGIA tipologia)
        {
            Nome = nome;
            Cognome = cognome;
            Stipendio = stipendio;
            Tipologia = tipologia;
        }

        public bool Equals(Meccanico? other)
        {
            if(this.Nome == other.Nome && this.Cognome == other.Cognome && this.Stipendio == other.Stipendio && this.Tipologia == other.Tipologia)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return base.ToString()+$", Tipologia={Tipologia}";
        }

        public override double Tredicesima()
        {
            return Stipendio+((Stipendio*93)/100);
        }
    }
}
