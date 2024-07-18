using System.ComponentModel.Design;

namespace Doro_Esercitazione
{
    internal class Program
    {
        /*
         * Costruire il Main con la possibilità di scegliere tra le seguenti azioni (creare un menu testuale):

Visualizzare l’elenco dei venditori
Visualizzare l’elenco dei meccanici
Stampa di un certo ordine, da cercare in base al codice ordine dato in input
Visualizzare l'elenco degli ordini effettuato da un certo venditore. Da input viene fornito il cognome del venditore
Visualizzare l'elenco degli ordine in cui è presente un certo prodotto, da cercare in base al codice prodotto dato in input
Termina il programma
        */
        static void Main(string[] args)
        {
            OrdiniBiz obiz = new OrdiniBiz();
            VenditoriBiz vbiz = new VenditoriBiz();
            MeccaniciBiz mbiz = new MeccaniciBiz();

            vbiz.Venditori = new List<Venditore> { new Venditore("Paolo","Rossi",1500,SETTORE.AUTO), new Venditore("Stefano","Giusti",1250,SETTORE.MOTO), new ResponsabileVenditori("Gianna","Bianchi",1700,SETTORE.AUTO)};
            obiz.Ordini = new List<Ordine> { new Ordine(DateTime.Today,new List<Acquisto>{ new Acquisto(new Prodotto("ALPA01","Pane","Pane di segale", 1.50), 5) }, vbiz.Venditori[0]),
                new Ordine(DateTime.Today,new List<Acquisto>{ new Acquisto(new Prodotto("NACZ04","Calze","Calze in lana", 4.50), 2), new Acquisto(new Prodotto("MOFS04","Mouse","Mouse ergonomico", 27.00), 1) }, vbiz.Venditori[2]),
                new Ordine(DateTime.Today,new List<Acquisto>{ new Acquisto(new Prodotto("TZAF01","Salsa tzatziki","Salsa di origine greca", 3.99), 2) }, vbiz.Venditori[1])};
            mbiz.Meccanici = new List<Meccanico> { new Meccanico("Andrea", "Verdi", 1200, TIPOLOGIA.CARROZZERIA), new Meccanico("Giada", "Limoni", 1300, TIPOLOGIA.MECCANICA) };


            int scelta = 0;
            while (scelta!=6) {
                scelta = menu();
                switch (scelta) {
                    case 1:
                        foreach (var vend in vbiz.Venditori)
                        {
                            Console.WriteLine(vend);
                        }
                            break;
                    case 2:
                        foreach (var meccanico in mbiz.Meccanici)
                        {
                            Console.WriteLine(meccanico);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Inserire il codice dell'ordine: ");
                        string codice = Console.ReadLine();
                        Ordine or = obiz.CercaOrdineByCodice(codice);
                        if (or != null)
                        {
                            or.StampaOrdine();
                        } else
                        {
                            Console.WriteLine("L'ordine selezionato non è stato trovato. Operazione fallita");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Inserire il cognome del venditore: ");
                        string cognome = Console.ReadLine();
                        var venditore = vbiz.FindByCognome(cognome);
                        if (venditore != null)
                        {
                            var lista = obiz.CercaByVenditore(venditore);
                            if(lista != null)
                            {
                                foreach (var item in lista)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            } else
                            {
                                Console.WriteLine("Il venditore non è collegabile a nessun ordine.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Venditore non trovato");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Inserire il codice prodotto: ");
                        string code = Console.ReadLine();
                        var listOrdini = obiz.FindOrdiniProdotto(code);
                        foreach (var item in listOrdini)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;

                 



                    



                }
            
            
            }
        }

        static int menu()
        {
            string strmenu = """
                ========MENU ITS=======
                1) Visualizzare l’elenco dei venditori
                2) Visualizzare l’elenco dei meccanici
                3) Stampa di un certo ordine, da cercare in base al codice ordine dato in input
                4) Visualizzare l'elenco degli ordini effettuato da un certo venditore. Da input viene fornito il cognome del venditore
                5) Visualizzare l'elenco degli ordine in cui è presente un certo prodotto, da cercare in base al codice prodotto dato in input
                6) Termina il programma
                Scelta:
                """;
            Console.Write(strmenu);
            int scelta = int.Parse(Console.ReadLine());
            return scelta;
        }
    }
}
