namespace StudentiITS
{
    /*
     * Si vuole sviluppare un software per registrare gli esami sostenuti dagli studenti iscritti 
     * ad un certo corso ITS. Di ogni studente si conoscono le seguenti informazioni: matricola, 
     * cognome, nome, data di nascita, luogo di nascita, indirizzo di residenza(via, cap, città, 
     * sigla provincia), telefono, email, titolo di studio. 

Le materie oggetto d'esame sono quelle previste dal piano di studio dello specifico corso a cui lo studente
    è iscritto. Di ogni materia è necessario conoscere: codice, denominazione, descrizione, numero di ore.

In merito alla registrazione dell'esame è necessario avere il voto assegnato e 
    la data in cui è sostenuto l'esame.

Si consideri un elenco di studenti, un elenco di materie e un elenco di esami sostenuti. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ITS!");
            int scelta = -1;
            ITSBiz ITS = new ITSBiz();
            /*
            List<Studente> studente = new List<Studente>();
            List<Materia> materie = new List<Materia>();
            List<Esame> esami = new List<Esame>();
            ITS.Studenti = studente;
            ITS.Materie = materie;
            ITS.Esami = esami;
            */

            do
            {
                scelta = menu();
                switch (scelta)
                {
                    case 1:
                        LeggiStudenti(ITS.Studenti);
                        Console.WriteLine(ITS.Studenti);
                        break;
                    case 2: 
                        LeggiMaterie(ITS.Materie);
                        break;
                    case 3: 
                        LeggiEsami(ITS.Esami);
                        break;
                }

                } while (scelta != 0) ;
            




            }

        static int menu()
            {
                string strmenu = """
                ========MENU ITS=======
                1) visualizzazione dell'elenco degli studenti con tutti e solo i dati disponibili
                2) visualizzazione dell'elenco delle materie con tutti e solo i dati disponibili
                3) visualizzazione dell'elenco degli esami sostenuti: Nominativo studente, materia, data e voto
                0) Uscita.
                Scelta:
                """;
                Console.Write(strmenu);
                int scelta = int.Parse(Console.ReadLine());
                return scelta;
            }

            static void LeggiStudenti(List<Studente> studenti)
            {
                string path = "..\\..\\..\\file\\StudentiITS.csv";
                StreamReader stream = new StreamReader(path);
                while (!stream.EndOfStream)
                {
                    var testo = stream.ReadLine();
                    string[] dati = testo.Split(";");
                    Studente studente = new Studente(dati[0], dati[1], dati[2], DateOnly.Parse(dati[3]), dati[4], dati[5], dati[6], dati[7], dati[8], dati[9], dati[10], dati[11]);
                    studenti.Add(studente);


                }
                stream.Close();
            }
            static void LeggiMaterie(List<Materia> materie)
            {
                string path = "..\\..\\..\\file\\MaterieITS.csv";
                StreamReader stream = new StreamReader(path);
                while (!stream.EndOfStream)
                {
                    var testo = stream.ReadLine();
                    string[] dati = testo.Split(";");
                    Materia materia = new Materia(int.Parse(dati[0]), dati[1], dati[2], int.Parse(dati[3]));
                    materie.Add(materia);

                }
                stream.Close();
            }

            static void LeggiEsami(List<Esame> esami)
            {
                string path = "..\\..\\..\\file\\EsamiITS.csv";
                StreamReader stream = new StreamReader(path);
                while (!stream.EndOfStream)
                {
                    var testo = stream.ReadLine();
                    string[] dati = testo.Split(";");
                    Esame esame = new Esame(dati[0], dati[1], double.Parse(dati[2]), DateOnly.Parse(dati[3]));
                    esami.Add(esame);

                }
                stream.Close();
            }
        }
    }

