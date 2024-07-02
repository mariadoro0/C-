namespace FileCSV_Lettura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrittura su file CSV!");

            //lettura del dato su file
            string path = "..\\..\\..\\file\\Persona.csv";
            StreamReader stream = new StreamReader(path);
            string testo = stream.ReadToEnd();
            stream.Close();

            //creazione persona
            Persona persona = new Persona();
            string[] dati = testo.Split(";");
            persona.Nome = dati[0];
            persona.Cognome = dati[1];
            persona.DataNascita=DateTime.Parse(dati[2]);
            persona.LuogoNascita=dati[3];
            switch (dati[4])
            {
                case "ALTRO": persona.Sesso = SESSO.ALTRO; break;
                case "M": persona.Sesso = SESSO.M; break;
                case "F": persona.Sesso= SESSO.F; break;
            }

            Console.WriteLine($"Dati della persona: {persona}");
            Console.WriteLine($"Età della persona: {persona.Eta()}");

        }
    }
}
