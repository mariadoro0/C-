namespace Quadrilateri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t Ereditarietà! \t");

            Quadrilatero qd = new Quadrilatero(2,2,3,4);
            Console.WriteLine(qd);

            Rettangolo r = new Rettangolo(1.25, 3.2);
            Console.WriteLine(r);

            Quadrato q = new Quadrato(1);
            Console.WriteLine(q);

        }
    }
}
