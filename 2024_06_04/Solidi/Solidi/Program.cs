namespace Solidi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Materiale acciaio = new Materiale() { Denominazione = TipoMateriale.ACCIAIO, PesoSpecifico = 7.85 };
            Materiale tungsteno = new Materiale() { Denominazione = TipoMateriale.TUNGSTENO, PesoSpecifico = 19.10 };
            Materiale piombo = new Materiale() { Denominazione = TipoMateriale.PIOMBO, PesoSpecifico = 11.34 };

            Cubo cubo = new Cubo(1, tungsteno);
            Console.WriteLine(cubo);
            Console.WriteLine("\n");
            Sfera s = new Sfera(1,acciaio);
            Console.WriteLine(s);
            Console.WriteLine("\n");
            Cilindro cl = new Cilindro(1, 2, acciaio);
            Console.WriteLine(cl);
            Console.WriteLine("\n");
        }
    }
}
