using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace GestioneMessaggi
{
    /*
     * Esercizio n. 2 - GestioneMessaggi

Si hanno a disposizione una serie di messaggi organizzati in un archivio. Di ogni messaggio si conosce il mittente, il destinatario, l’oggetto, il testo del messaggio, la data e l’ora, la priorità(bassa, normale,alta).

Le operazioni concesse sono:

inserire un nuovo messaggio
cercare un messaggio per mittente
cercare un messaggio per destinatario
contare quanti messaggi sono stati inseriti dopo una certa data
Creare un menu testuale con la possibilità di scegliere l’operazione specifica.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Messaggi!");
            string menu = "\n*******MENU' MESSAGGI********\n" +
                "1) Inserire un nuovo messaggio.\n" +
                "2) Cerca messaggio per mittente.\n" +
                "3) Cerca un messaggio per destinatario.\n" +
                "4) Conta messaggi inseriti dopo una data.\n" +
                "5) Stampa messaggi.\n"+
                "0) Uscita.\n"+
                "Scelta: ";
            int scelta;
            MessaggiBiz biz = new MessaggiBiz();;
            var lista = new List<Messaggio> {
                new Messaggio { Mittente = new Utente{Nome="Maria", Cognome="Doro" }, Destinatario = new Utente{Nome="Davide", Cognome="Ossi" },Date = new DateTime(2019, 12, 14, 23, 40, 0), Text = "Ti amo!", Priority = PRIORITY.ALTA },
                new Messaggio { Mittente = new Utente{Nome="Davide", Cognome="Ossi" }, Destinatario = new Utente{Nome="Maria", Cognome="Doro" }, Date = new DateTime(2019, 12, 14, 23, 41, 3), Text = "Anche io!", Priority = PRIORITY.ALTA },
                new Messaggio { Mittente = new Utente{Nome="Maria Rosa", Cognome="Diaz" }, Destinatario = new Utente{Nome="Mary", Cognome="Doro" }, Date = new DateTime(2024, 06, 26, 8, 40, 0), Text = "Sei in tram?", Priority = PRIORITY.BASSA },
                new Messaggio { Mittente = new Utente{Nome="Arianna", Cognome="Ossi" }, Destinatario = new Utente{Nome="Eleonora", Cognome="Ossi" }, Date = new DateTime(2024, 6, 25, 16, 30, 0), Text = "Domani usciamo?", Priority = PRIORITY.NORMALE }};
            biz.archivio = lista;
            do
            {
                Console.Write(menu);
                scelta = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                switch (scelta)
                {
                    case 1:
                        biz.aggiungiMessaggio(creaMessaggio());
                        Console.WriteLine("Messaggio aggiunto con successo.");
                        break;

                    case 2:
                        Utente um = creaUtente();
                        int indexM = biz.cercaMittente(um);
                        if (indexM == -1)
                        {
                            Console.WriteLine("Non ci sono messaggi da parte del mittente selezionato.");
                        }
                        else
                        {
                            Console.WriteLine(biz.archivio[indexM]);
                        }
                        break;

                    case 3:
                        Utente ud = creaUtente();
                        int indexD = biz.cercaDestinatario(ud);
                        if (indexD == -1)
                        {
                            Console.WriteLine("Non ci sono messaggi per il destinatario selezionato.");
                        }
                        else
                        {
                            Console.WriteLine(biz.archivio[indexD]);
                        }
                        break;

                    case 4:
                        DateTime data = creaData();
                        int counter = biz.contaPerData(data);
                        Console.WriteLine($"Sono stati trovati {counter} messaggi dalla data {data} in poi.");
                        break;

                    case 5:
                        string s = biz.StampaMessaggi();
                        Console.WriteLine(s);
                        break;
                }

            }while(scelta!=0);


        }

        public static Messaggio creaMessaggio()
        {
            Console.Write("MITTENTE\n");
            Utente mittente = creaUtente();
            Console.Write("DESTINATARIO\n");
            Utente destinatario = creaUtente();
            Console.Write("Inserire testo: ");
            string testo = Console.ReadLine();
            DateTime data = DateTime.Now;
            Console.Write("Inserire la priorità: ");
            var pr = Console.ReadLine().ToUpper();
            if (pr == "BASSA")
            {
                Messaggio m = new Messaggio { Mittente = mittente, Destinatario = destinatario, Date = data, Text = testo, Priority = PRIORITY.BASSA };
                return m;
            } else if (pr == "NORMALE")
            {
                Messaggio m = new Messaggio { Mittente = mittente, Destinatario = destinatario, Date = data, Text = testo, Priority = PRIORITY.NORMALE };
                return m;
            }
            else
            {
                Messaggio m = new Messaggio { Mittente = mittente, Destinatario = destinatario, Date = data, Text = testo, Priority = PRIORITY.ALTA };
                return m;
            }
            
        }

        public static Utente creaUtente()
        {   
            Console.Write("Inserire nome: ");
            string nome = Console.ReadLine();
            Console.Write("Inserire cognome: ");
            string cognome = Console.ReadLine();
            Utente u = new Utente{Nome = nome, Cognome = cognome};
            return u;
        }

        public static DateTime creaData()
        {
            Console.Write("Inserire l'anno': ");
            int anno = int.Parse(Console.ReadLine());
            Console.Write("Inserire il mese': ");
            int mese = int.Parse(Console.ReadLine());
            Console.Write("Inserire il giorno': ");
            int giorno = int.Parse(Console.ReadLine());
            DateTime data = new DateTime(anno, mese, giorno, 0, 0, 0);
            return data;
        }
    }
}
