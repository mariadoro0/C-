using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientiLinq
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public DateOnly DataNascita { get; set; }

        public Cliente(string nome, string cognome, string codiceFiscale, DateOnly dataNascita)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codiceFiscale;
            DataNascita = dataNascita;
        }

        public override string ToString()
        {
            return $"{{{nameof(Nome)}={Nome}, {nameof(Cognome)}={Cognome}, {nameof(CodiceFiscale)}={CodiceFiscale}, {nameof(DataNascita)}={DataNascita.ToString()}}}";
        }
    }
}
