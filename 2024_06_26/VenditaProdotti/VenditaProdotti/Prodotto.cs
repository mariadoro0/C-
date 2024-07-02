using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenditaProdotti
{
    internal abstract class Prodotto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Date)}={Date.ToString()}";
        }
    }
}
