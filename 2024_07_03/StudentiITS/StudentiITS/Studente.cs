using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* matricola, 
     * cognome, nome, data di nascita, luogo di nascita, indirizzo di residenza(via, cap, città, 
     * sigla provincia), telefono, email, titolo di studio. */

namespace StudentiITS
{
    internal class Studente
    {
        public string Matricola { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateOnly DataNascita { get; set; }
        public string LuogoNascita { get; set; }

        public string Via { get; set; }
        public string Cap { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }

        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Titolo { get; set; }

        public Studente(string matricola, string cognome, string nome, DateOnly dataNascita, string luogoNascita, string via, string cap, string citta, string provincia, string telefono, string email, string titolo)
        {
            Matricola = matricola;
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            LuogoNascita = luogoNascita;
            Via = via;
            Cap = cap;
            Citta = citta;
            Provincia = provincia;
            Telefono = telefono;
            Email = email;
            Titolo = titolo;
        }

        public override string ToString()
        {
            return $"{{{nameof(Matricola)}={Matricola}, {nameof(Nome)}={Nome}, " +
                $"{nameof(Cognome)}={Cognome}, {nameof(DataNascita)}={DataNascita.ToString()}," +
                $" {nameof(LuogoNascita)}={LuogoNascita}, {nameof(Telefono)}={Telefono}, " +
                $"{nameof(Email)}={Email}, {nameof(Titolo)}={Titolo}}}";
        }
    }
}
