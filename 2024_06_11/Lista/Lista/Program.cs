using System.Collections;

namespace Lista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ArrayList!!");
            var lista = new ArrayList();
            Console.WriteLine($"Capacità: {lista.Capacity}");
            Console.WriteLine($"Lunghezza: {lista.Count}");

            lista.Add("ciao");
            lista.Add(3);
            lista.Add(3.14);
            lista.Add(true);
            lista.Add('d');
            lista.Insert(2, "mondo");
            lista.Remove(3);

            Console.WriteLine($"Capacità: {lista.Capacity}");
            Console.WriteLine($"Lunghezza: {lista.Count}");
            foreach( var item in lista )
            {
                Console.WriteLine(item+"--->"+ item.GetType().Name);
                
            }
        }
    }
}
