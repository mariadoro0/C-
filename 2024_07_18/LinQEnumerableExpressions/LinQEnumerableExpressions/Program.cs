using System.ComponentModel;

namespace LinQEnumerableExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generare una lista si interi casuali");
            Random random = new Random();



            //estremi dell'intervallo

            Console.Write("Inserisci estremo inferiore: ");

            int inf = Convert.ToInt32(Console.ReadLine());



            int sup;

            do

            {

                Console.Write("Inserisci estremo superiore: ");

                sup = Convert.ToInt32(Console.ReadLine());



                if (inf >= sup)

                    Console.WriteLine("Estremo sup non valido!");

                else

                    break;



            } while (true);



            int tappo;

            do

            {

                Console.Write($"Inserisci il tappo terminatore della generazione della sequenza [{inf},{sup}]: ");

                tappo = Convert.ToInt32(Console.ReadLine());



                if (tappo < inf || tappo > sup)

                    Console.WriteLine($"Errore! Devi inserire un numero appartenente all'intervallo [{inf},{sup}]");

                else

                    break;



            } while (true);



            //creo la lista

            var list = new List<int>();



            //riempio la lista - l'ultimo numero della lista deve essere il tappo

            int estratto;

            do

            {

                estratto = random.Next(inf, sup + 1);

                list.Add(estratto);

            } while (estratto != tappo);

            var query = from tutti in list select tutti;
            Console.WriteLine(string.Join(",", query));
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());

            var querypos = from positivi in list where positivi >= 0 select positivi;
            Console.WriteLine($"Somma dei numeri solo positivi:  {querypos.Sum()}");

            var querydis = from dispari in list where dispari % 2 != 0 select dispari;
            Console.WriteLine(string.Join(", ",querydis));

            var querym3 = from multipli in list where multipli % 3 == 0 select multipli;
            Console.WriteLine(string.Join (", ",querym3));
        }
    }
}
