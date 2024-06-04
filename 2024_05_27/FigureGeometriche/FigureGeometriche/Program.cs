namespace FigureGeometriche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Figure Geometriche!");
            Quadrato q = new Quadrato();
            q.Lato = 12;
            Console.WriteLine("\n\tQuadrato:");
            Console.WriteLine(q);
            Cerchio c = new Cerchio(1.2);
            Console.WriteLine("\n\tCerchio:");
            Console.WriteLine(c.StampaDettaglio());
            Console.WriteLine("\n\tRettangolo:");

            //posso definire gli attributi di un oggetto in questo modo:
            Rettangolo r = new Rettangolo()
            {
                Base = 1.2,
                Altezza = 2.3
            };
            Console.WriteLine(r);

            Console.WriteLine("\n\tTriangolo:");
            Triangolo t = new Triangolo()
            {
                Lato1 = 2.3,
                Lato2 = 1.2,
                Lato3 = 2.3
            };
            Console.WriteLine(t);

            Console.WriteLine("\n\tPunto");
            Punto a = new Punto("A", 1.2, 2.3);
            Punto b = new Punto("B", -1.2, -1.1);

            Console.WriteLine(a.Stampa);
            Console.WriteLine(b.ToString);
            Console.WriteLine(a.Distanza(b));
            Console.WriteLine(b.Distanza(a));

            Punto z = new Punto(1,6);
            Console.WriteLine(z);

            Triangolo t1 = new Triangolo(a, b, z);
            Console.WriteLine(t1);
        }

    }
}
