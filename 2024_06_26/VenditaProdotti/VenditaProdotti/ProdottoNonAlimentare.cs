using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenditaProdotti
{
    internal class ProdottoNonAlimentare : Prodotto
    {
        public Composizione[] MadeOf { get; set; }


        public override string ToString()
        {
            return base.ToString()+$"{MadeOf.ToString()}";
        }
    }
}
