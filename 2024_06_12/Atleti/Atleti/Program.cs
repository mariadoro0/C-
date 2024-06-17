using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace Atleti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a1 = new Calciatore()
            {
                Cognome = "Del Paos",
                Nome = "Diego",
                NumeroPettorina = 21,
                Disciplina = "Calcio",
                Squadra = "ITS SSC",
                PartiteGiocate = 4,
                GoalSegnati = 9
            };
            Console.WriteLine(a1);

            Calciatore a2 = (Calciatore)a1.Clone();
            Console.WriteLine(a2);
            a2.Cognome = "Maradona";
            a2.NumeroPettorina = 10;
            a2.GoalSegnati = 5;


            if(a1.CompareTo(a2)==1) { Console.WriteLine($"{a1.Cognome} ha media superiore a {a2.Cognome}"); }
            if (a1.CompareTo(a2) == -1) { Console.WriteLine($"{a1.Cognome} ha media inferiore a {a2.Cognome}"); }

            Console.WriteLine(a1.Equals(a2));

        }
    }
}
