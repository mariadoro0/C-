namespace GestioneImmobili
{
    /*Si vuole progettare un’applicazione in grado di gestire gli immobili trattati da 
     * un’agenzia immobiliare. Gli immobili sono caratterizzati da un codice alfanumerico univoco, 
     * un indirizzo, cap, città e da una superficie espressa in mq attraverso un numero intero, 
     * proposta economica della vendita. L’agenzia gestisce diverse tipologie di immobili: 
     * box, appartamenti e ville.

Per i box è riportato in più il numero di posti auto. Per gli appartamenti è riportato anche il 
    numero di vani e il numero di bagni, e per le ville è previsto, in aggiunta, la dimensione in 
    mq di giardino rispetto all’appartamento.

Si richiedono le seguenti azioni:

visualizzazione del numero di immobili
visualizzazione dell'elenco degli immobili
visualizzazione dell'elenco di appartamenti
visualizzazione dell'elenco delle ville
visualizzazione dell'elenco dei box
visualizzazione dell'elenco degli immobili ubicati in una certa città
visualizzazione della scheda di dettaglio di un certo immobile individuato tramite codice
Si richiede l'uso di un menu testuale per poter scegliere una delle azioni precedentemente elencate.

*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gestione Immobili!");
            int scelta = -1;
            var lista = new List<Immobile> { new Box { Id = "Bo1", Indirizzo = "Corso Pippo 12", Cap = "10100", Citta = "Torino", Metratura=500, Proposta = 10000, PostiAuto = 2 }, 
                    new Box { Id = "Bo2", Indirizzo = "Corso Baudo 15", Cap = "10101", Citta = "Torino",Metratura=15, Proposta = 15000, PostiAuto = 3 }, 
                    new Appartamento { Id = "Ap1", Indirizzo = "Via Giuseppino 23", Cap = "10101", Citta = "Genova",Metratura=85, Proposta = 50000, NumVani = 6, NumBagni = 2 }, 
                    new Appartamento { Id = "Ap2", Indirizzo = "Via Cesariano 44", Cap = "15021", Citta = "Roma",Metratura=115, Proposta = 100000, NumVani = 10, NumBagni = 3 }, 
                    new Villa { Id = "Vi1", Indirizzo = "Via Cesariano 44", Cap = "15021", Citta = "Pianezza", Metratura=250, Proposta = 1000000, NumVani = 23, NumBagni = 5, Giardino = 1000 },
                    new Villa { Id = "Vi2", Indirizzo = "Via Cesariano 44", Cap = "15021", Citta = "Napoli", Metratura=300, Proposta = 500000, NumVani = 25, NumBagni = 7, Giardino = 10000 } };

            ImmobiliBiz immobili = new ImmobiliBiz(lista);


            do
            {
                scelta = menu();
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine($"Sono presenti {immobili.ContaImmobili()} immobili nella lista.");
                        break;
                    case 2:
                        Console.WriteLine($"====ELENCO IMMOBILI=====");
                        Console.WriteLine(immobili.StampaImmobili());
                        break;
                    case 3:
                        Console.WriteLine($"====ELENCO APPARTAMENTI=====");
                        Console.WriteLine(immobili.StampaAppartamenti());
                        break;
                    case 4:
                        Console.WriteLine($"====ELENCO VILLE=====");
                        Console.WriteLine(immobili.StampaVille());
                        break;
                    case 5:
                        Console.WriteLine($"====ELENCO BOX=====");
                        Console.WriteLine(immobili.StampaBox());
                        break;
                    case 6:
                        Console.Write("Inserire la città: ");
                        string citta = Console.ReadLine();
                        Console.WriteLine($"====ELENCO IMMOBILI A {citta.ToUpper()}=====");
                        Console.WriteLine(immobili.ImmobiliCitta(citta));
                        break;
                    case 7:
                        Console.Write("Inserire il codice dell'immobile: ");
                        string code = Console.ReadLine();
                        Console.WriteLine($"====ELENCO IMMOBILI=====");
                        Console.WriteLine(immobili.StampaDettaglioImmobile(code)+"\n");
                        break;
                }
            } while (scelta != 0);

            }

        static int menu()
        {
            string strmenu = """
                ========MENU IMMOBILI=======
                1) Visualizza il numero di immobili.
                2) Visualizza l'elenco degli immobili.
                3) Visualizza l'elenco degli appartamenti.
                4) Visualizza l'elenco delle ville.
                5) Visualizza l'elenco dei box.
                6) Visualizza l'elenco degli immobili in una città.
                7) Stampa al dettaglio tramite codice.
                0) Uscita.
                Scelta:
                """;
            Console.Write(strmenu);
            int scelta = int.Parse(Console.ReadLine());
            return scelta;
        }
    }
}
