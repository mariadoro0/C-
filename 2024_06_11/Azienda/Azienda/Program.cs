namespace Azienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Azienda Petrolchimica!");

            DipendentiBiz biz = new DipendentiBiz();
            biz.dipendenti = new Dipendente[] {
                new Amministrativo { cognome="Del Mastro", nome="Giulia", oreLavorate=35, pagaOraria=41, mansione=TipoMansioneAmministrativo.CONTABILE},
                new Amministrativo { cognome = "Rossi", nome = "Paolo", oreLavorate = 70, pagaOraria = 23, mansione = TipoMansioneAmministrativo.HR },
                new Amministrativo { cognome="Donati", nome="Donatello", oreLavorate=35, pagaOraria=41, mansione=TipoMansioneAmministrativo.CONTABILE},
                new Amministrativo { cognome = "Polo", nome = "Marco", oreLavorate = 70, pagaOraria = 23, mansione = TipoMansioneAmministrativo.HR },
                new Amministrativo { cognome = "Verdi", nome = "Federica", oreLavorate = 60, pagaOraria =50, mansione=TipoMansioneAmministrativo.DIRETTORE},
                new Operaio { cognome = "Sassi", nome = "Pietro", oreLavorate = 80, pagaOraria =22, mansione=TipoMansioneOperaio.MANUTENTORE},
                new Operaio { cognome = "Bolla", nome = "Bernardo", oreLavorate = 100, pagaOraria =23, mansione=TipoMansioneOperaio.MANUTENTORE},
                new Operaio { cognome = "Limoni", nome = "Franco", oreLavorate = 97, pagaOraria =24, mansione=TipoMansioneOperaio.INSTALLATORE},
                new OperaioSpecializzato { cognome = "De Luca", nome = "Luca", oreLavorate = 130, pagaOraria = 16, mansione = TipoMansioneOperaio.INSTALLATORE, nMissioni=3, indennita=200 }
                };

            string menu = "\nScegli una tra le seguenti operazioni: \n" +
                "1. Visualizzare l'elenco dei dipendenti con tutti i loro dati\r\n" + "" +
                "2. Visualizzare l'elenco degli amministrativi\r\n" + "" +
                "3. Visualizzare l'elenco degli operai\r\n" + "" +
                "4. Visualizzare l'elenco degli operai specializzati\r\n" + "" +
                "5. Visualizzare l'elenco degli operai che hanno stipendio superiore a 2000,00 euro\r\n" + "" +
                "6. Visualizzare l'elenco degli operai manutentori\r\n" + "" +
                "7. Visualizzare la scheda in dettaglio del direttore amministrativo\r\n" + "" +
                "8. Uscire dal programma" +
                "\n\nScelta: ";
            int scelta;
            do {
                Console.Write(menu);
                scelta=Convert.ToInt32(Console.ReadLine());

                switch (scelta)
                {
                    case 1: Console.WriteLine("****STAMPA DIPENDENTI*****\n"+biz.StampaDipendenti()); break;
                    case 2: Console.WriteLine("****STAMPA AMMINISTRATIVI*****\n" + biz.StampaAmministrativi()); break;
                    case 3: Console.WriteLine("****STAMPA OPERAI*****\n" + biz.StampaOperai()); break;
                    case 4: Console.WriteLine("****STAMPA OPERAI SPECIALIZZATI*****\n" + biz.StampaOperaiSpec()); break;
                    case 5: Console.WriteLine("****STAMPA OPERAI CON STIPENDIO SOPRA 2K*****\n" + biz.StampaStipendio2k()); break;
                    case 6: Console.WriteLine("****STAMPA MANUTENTORI*****\n" + biz.StampaManutentori()); break;
                    case 7: Console.WriteLine("****STAMPA DIRETTORE*****\n" + biz.StampaSchedaDirettore()); break;
                    case 8: Console.WriteLine("Programma terminato.");break;
                    default: Console.WriteLine("Errore.");break;
                }
            }
            while (scelta != 8);



        }

        



    }
}
