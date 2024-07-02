using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCSV_Scrittura
{
    internal class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string LuogoNascita { get; set; }
        public SESSO Sesso { get; set; }


        public int Eta()
        {
            if (DateTime.Now.Month > DataNascita.Month || (DateTime.Now.Month == DataNascita.Month && DateTime.Now.Day >= DataNascita.Day))
            {
                return DateTime.Now.Year - DataNascita.Year;
            }
            else
            {
                return DateTime.Now.Year - DataNascita.Year - 1;
            }
        }

        public string StampaCVS()
        {
            return $"{Nome};{Cognome};{DataNascita.ToShortDateString()};{LuogoNascita};{Sesso.ToString()}";
        }




        public override string ToString()
        {
            return $"{{{nameof(Nome)}={Nome}, {nameof(Cognome)}={Cognome}, {nameof(DataNascita)}={DataNascita.ToString()}, {nameof(LuogoNascita)}={LuogoNascita}, {nameof(Sesso)}={Sesso.ToString()}}}";
        }
    }
}
