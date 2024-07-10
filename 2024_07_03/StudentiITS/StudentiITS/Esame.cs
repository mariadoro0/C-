using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentiITS
{
    internal class Esame
    {
        
        public string MatricolaStudente { get; set; }
        public string CodiceMateria { get; set; }
        public double Voto { get; set; }
        public DateOnly Data { get; set; }

        public Esame(string matricolaStudente, string codiceMateria, double voto, DateOnly data)
        {
            MatricolaStudente = matricolaStudente;
            CodiceMateria = codiceMateria;
            Voto = voto;
            Data = data;
        }

        public override string ToString()
        {
            return $"{{{nameof(Materia)}={CodiceMateria}, {nameof(Studente)}={MatricolaStudente}, {nameof(Voto)}={Voto.ToString()}, {nameof(Data)}={Data.ToString()}}}";
        }
    }
}
