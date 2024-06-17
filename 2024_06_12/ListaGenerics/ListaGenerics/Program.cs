using FigureGeometriche;

namespace ListaGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lista con Generics!");

            var lista = new List<int>() { 12, 3, 4, -56, -45, 23, 17 };
            Console.WriteLine(string.Join(";", lista));

            var lista2 = new List<Quadrato>() { new Quadrato() { Lato = 4 }, new Quadrato() { Lato = 5 }, new Quadrato() { Lato = 6 } };
            Console.WriteLine(string.Join("\n\n", lista2));
        }
    }
}
