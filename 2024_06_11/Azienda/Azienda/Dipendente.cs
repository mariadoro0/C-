using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    internal class Dipendente
    {
        public string cognome { get; set; }
        public string nome { get; set; }
        public double pagaOraria { get; set; }
        public double oreLavorate { get; set; }



        public virtual double Stipendio()
        {
            return pagaOraria * oreLavorate;
        }

        public override string ToString()
        {
            return $"{{{nameof(cognome)}={cognome}, {nameof(nome)}={nome}, {nameof(pagaOraria)}={pagaOraria.ToString()}, {nameof(oreLavorate)}={oreLavorate.ToString()}, Stipendio:{Stipendio().ToString()}}}";
        }
    }
}
