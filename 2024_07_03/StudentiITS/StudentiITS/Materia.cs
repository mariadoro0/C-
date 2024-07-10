using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentiITS
{
    internal class Materia
    {
        public int Id { get; set; }
        public string Denominazione { get; set; }
        public string? Descrizione { get; set; }
        public int Ore { get; set; }

        public Materia(int id, string denominazione, string? descrizione, int ore)
        {
            Id = id;
            Denominazione = denominazione;
            Descrizione = descrizione;
            Ore = ore;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Denominazione)}={Denominazione}, {nameof(Descrizione)}={Descrizione}, {nameof(Ore)}={Ore.ToString()}}}";
        }
    }
}
