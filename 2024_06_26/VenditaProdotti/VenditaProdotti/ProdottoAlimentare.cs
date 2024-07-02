using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenditaProdotti
{
    internal class ProdottoAlimentare : Prodotto
    {
        public DateTime Expiration { get; set; }

        public override string ToString()
        {
            return base.ToString()+$"Expiration date={Expiration.ToString()}";
        }
    }
}
