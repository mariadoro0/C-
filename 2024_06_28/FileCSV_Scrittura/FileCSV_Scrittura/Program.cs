namespace FileCSV_Scrittura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrittura su file CSV!");
            //creazione persona
            Persona persona = new Persona();

            //inizializzazione persona
            Console.WriteLine("Inserire il cognome: ");
            persona.Cognome = Console.ReadLine();
            Console.WriteLine("Inserire il nome: ");
            persona.Nome = Console.ReadLine();
            Console.WriteLine("Inserire la data di nascita: ");
            persona.DataNascita =DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserire il luogo di nascita: ");
            persona.LuogoNascita = Console.ReadLine();
            Console.WriteLine("Inserire il sesso [0-Altro, 1-Maschio,2-Femmina]: ");
            persona.Sesso = (SESSO)int.Parse(Console.ReadLine());



            //scrittura del dato su file
            string path = "..\\..\\..\\file\\Persona.csv";
            StreamWriter stream = new StreamWriter(path);
            stream.Write(persona.StampaCVS());
            stream.Close();

            Console.WriteLine("Fatto!");
        }
    }
}
