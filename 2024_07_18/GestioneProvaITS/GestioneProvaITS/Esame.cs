using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProvaITS
{
    internal class Esame
    {
        public Studente Studente { get; set; }
        public int VotoProvaTeorica { get; set; }
        public int VotoProvaPratica { get; set; }
        public int VotoProvaOrale { get; set; }
        
        public int VotoFinale() => VotoProvaOrale + VotoProvaPratica + VotoProvaTeorica;

        public Esame(Studente studente, int votoProvaTeorica, int votoProvaPratica, int votoProvaOrale)
        {
            Studente = studente;
            VotoProvaTeorica = votoProvaTeorica;
            VotoProvaPratica = votoProvaPratica;
            VotoProvaOrale = votoProvaOrale;
            
        }

        public override string ToString()
        {
            return $"{{{nameof(Studente)}={Studente}, {nameof(VotoProvaTeorica)}={VotoProvaTeorica.ToString()}, {nameof(VotoProvaPratica)}={VotoProvaPratica.ToString()}, {nameof(VotoProvaOrale)}={VotoProvaOrale.ToString()}, {VotoFinale()}}}";
        }
    }
}
