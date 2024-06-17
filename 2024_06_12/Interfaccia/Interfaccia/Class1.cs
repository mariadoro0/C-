using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaccia
{
    internal class Class1 : Interfaccia, Interfaccia2, InterfacciaGenerale
    {
        public string Metodo1()
        {
            return "Heroes never die.";
        }

        public int Metodo2()
        {
            return 14;
        }

        public void Metodo3()
        {
            Console.WriteLine("Metodo 3!");
        }

        public double Metodo4()
        {
            throw new NotImplementedException("Metodo non implementato.");
        }

        public bool Metodo5(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
