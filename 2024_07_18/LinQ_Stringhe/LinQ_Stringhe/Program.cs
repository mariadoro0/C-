using System.Threading.Tasks.Dataflow;

namespace LinQ_Stringhe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nomi = {"Pietro","Mario","Giulia","Francesca","Laura","Piero","Antonio","Vito","Antonella","Giada","Rossella","Simone","Saverio","Rosa","Michela","Andrea","Mattia","Ilaria","Alex","Vanessa","Ciro", "" +
                    "Elia", "Giuditta", "Stefano", "Alessandro", "Carlo", "Drusilla", "Dorothea", "Lucilla", "Marialuisa", "Marcolino", "Pietrangelo", "Ermenegildo","Gavino","Rosa","Matilde","Margherita","Catalin","Stefan","Mauro",
                    "Maria","Eand","Davide","Cristian","Tracer","Mercy","Illari","Diva","Cassidy","Sombra","Mei","Moira","Ana","Lucio","Baptiste","Zarya","Orisa","Mauga","Symmetra","Kiriko"};

            var count = nomi.Count();

            Console.WriteLine("Stampa elenco nomi");
            var query= from tutti in nomi select tutti;
            Console.WriteLine(string.Join(", ", query));


            Console.WriteLine();
            Console.WriteLine("Elenco dei nomi che iniziano con a");
            var query2 = from iniziaA in nomi
                         where iniziaA.StartsWith('A')
                         select iniziaA;
            Console.WriteLine(string.Join(", ", query2));

            Console.WriteLine();
            Console.WriteLine("Nomi in ordine alfabetico crescente");
            var query3 = from ordineA in nomi
                         orderby ordineA
                         select ordineA;
            Console.Write(string.Join(", ", query3));



            Console.WriteLine();
            Console.WriteLine("Stampa elenco dei nomi di lunghezza pari a 7 in ordine decrescente");
            var query4= from lunghezzaDesc in nomi
                        where lunghezzaDesc.Length==7
                        orderby lunghezzaDesc descending
                        select lunghezzaDesc;
            Console.WriteLine(string.Join(", ", query4));


            Console.WriteLine();
            Console.WriteLine("Stampa l'elenco dei nomi tutti maiuscoli");
            var query5 = from maiuscoli in nomi
                         select maiuscoli.ToUpper();
            Console.WriteLine(string.Join(", ", query5));
        }
    }
}
