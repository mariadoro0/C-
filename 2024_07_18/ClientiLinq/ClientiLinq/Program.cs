namespace ClientiLinq
{
    /*
     * Creare un lista di clienti. Di ogni cliente si conosce il codice fiscale, il cognome, il nome, la sua data di nascita.

Si richiede di effettuare le seguenti interrogazioni:

stampare l'elenco dei soli codici fiscali
stampare il nominativo, ovvero cognome e nome, di ogni cliente nato dopo il 1980


Utilizzare per effettuare le interrogazioni il linguaggio LInQ e le Lambda Expression
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clienti = new List<Cliente>()  {
            new Cliente("Mario", "Rossi", "RSSMRA80A01H501Z", new DateOnly(1980, 1, 1)),
            new Cliente("Luigi", "Verdi", "VRDLGU85B02H501Y", new DateOnly(1985, 2, 2)),
            new Cliente("Anna", "Bianchi", "BNCHNN90C03H501X", new DateOnly(1990, 3, 3)),
            new Cliente("Giulia", "Neri", "NRIGLU95D04H501W", new DateOnly(1995, 4, 4)),
            new Cliente("Marco", "Gialli", "GLLMRC00E05H501V", new DateOnly(2000, 5, 5)),
            new Cliente("Elena", "Blu", "BLUELN05F06H501U", new DateOnly(2005, 6, 6)),
            new Cliente("Francesco", "Viola", "VLFNCS10G07H501T", new DateOnly(2010, 7, 7)),
            new Cliente("Chiara", "Rosa", "RSCHRA15H08H501S", new DateOnly(1958, 8, 8)),
            new Cliente("Davide", "Marrone", "MRNDVD20I09H501R", new DateOnly(1999, 9, 9)),
            new Cliente("Sara", "Azzurri", "AZZSRA25J10H501Q", new DateOnly(1988, 10, 10)),
            new Cliente("Luca", "Grigi", "GRGLUC30K11H501P", new DateOnly(2002, 11, 11)),
            new Cliente("Marta", "Arancioni", "ARNMRT35L12H501O", new DateOnly(2001, 12, 12)),
            new Cliente("Paolo", "Neri", "NRIPLO40M13H501N", new DateOnly(1993, 1, 13)),
            new Cliente("Silvia", "Verdi", "VRDSLV45N14H501M", new DateOnly(2000, 2, 14))
        };


            Console.WriteLine("\nCodici fiscali:");
            var queryCF = from cf in clienti select cf.CodiceFiscale;
            Console.WriteLine(string.Join("\n", queryCF));

            Console.WriteLine("\nClienti nati dopo il 1980");
            var queryAnno = from anno in clienti where anno.DataNascita >= new DateOnly(1980, 1, 1) select anno.Nome+' '+anno.Cognome;
            Console.WriteLine(string.Join ("\n", queryAnno));
            

        }
    }
}
