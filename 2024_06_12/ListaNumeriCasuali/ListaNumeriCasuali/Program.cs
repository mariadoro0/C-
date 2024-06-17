using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ListaNumeriCasuali
{
    internal class Program
    {
        private static int num;

        static void Main(string[] args)
        {
            Console.WriteLine("Lista con numeri casuali!");
            /* 
             * Riempire una lista con numeri interi generati casualmente 
             anche il numero di elementi generati è random
            l'intervallo è da 1 a 100

            da input acquisire un numero intero e trovarne la prima posizione all'interno della lista
            o se non è presente
            usare indexof
             */

            Random random = new Random();
            List<int> list = new List<int>();

            for (int i = 0; i < random.Next(1, 101) ; i++)
            {
                list.Add(random.Next(1, 101));
            }

            Console.WriteLine("Lista creata.");
            Console.WriteLine("Quale numero vuoi cercare?");
            int num;
            do {
                 num = int.Parse(Console.ReadLine());
                if(num<1 || num > 100)
                {
                    Console.WriteLine("Dato inserito non valido.");
                }

            } while (num < 1 || num > 100);


            int res = list.IndexOf(num);

            if (res == -1)
            {
                Console.WriteLine($"Il numero {num} non esiste all'interno della lista.");
            } else
            {
                Console.WriteLine($"Numero {num} trovato alla posizione {res} della lista");
            }
            Console.WriteLine("Numeri generati: "+string.Join(",", list));
            

        }
        
    }
}
