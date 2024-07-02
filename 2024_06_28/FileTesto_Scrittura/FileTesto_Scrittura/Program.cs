namespace FileTesto_Scrittura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrittura su file di testo!");

            string path = @"C:\file\Frase.txt";

            Console.Write("Inserisci la frase del giorno: ");
            string frase = Console.ReadLine();

            //accesso al file in modalità scrittura
            StreamWriter sw = new StreamWriter(path);
            //scrittura
            sw.Write(frase);
            //chiusura file
            sw.Close();

            Console.WriteLine("Operazione avvenuta con successo.");


        }
    }
}
