namespace GestioneProvaITS
{
    /*
     * Esercizio -GestioneProveITS

Si considerino gli esiti riportati dagli studenti di un certo corso. Gli esiti sono dati dalla somministrazione di tre prove: un test teorico, una prova tecnico pratica e un colloquio orale.

Per la prova teorica sono assegnati max 30 punti, per la prova tecnico pratica max 40 punti e per il colloquio orale max 30 punti.

Dello studente si conosce Cognome e Nome.

Si crei una lista di dati aventi le seguenti informazioni: Nominativo studente, prova teorica, prova pratica, colloquio orale, voto finale.

Si realizzino le seguenti interrogazioni come servizi:

stampa elenco risultati
stampa della media degli esami sostenuti
stampa della graduatoria in ordine decrescente per voto
Creare un menu testuale per visualizzare le varie richieste esposte precedentemente.



Utilizzare le funzioni Lambda. Popolare la lista utilizzando Intelligenza Artificiale.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            EsamiBiz Esami = new EsamiBiz();
             Esami.Esami = new List<Esame>
        {
            new Esame(new Studente("Mario", "Rossi"), 28, 35, 30),
            new Esame(new Studente("Luigi", "Verdi"), 25, 38, 29),
            new Esame(new Studente("Anna", "Bianchi"), 30, 40, 28),
            new Esame(new Studente("Giulia", "Neri"), 27, 36, 30),
            new Esame(new Studente("Marco", "Gialli"), 26, 34, 27),
            new Esame(new Studente("Elena", "Blu"), 29, 37, 30),
            new Esame(new Studente("Francesco", "Viola"), 30, 39, 30),
            new Esame(new Studente("Chiara", "Rosa"), 28, 35, 29),
            new Esame(new Studente("Davide", "Marrone"), 27, 36, 28),
            new Esame(new Studente("Sara", "Azzurri"), 30, 40, 30)
        };


            Console.WriteLine("Tutti gli esami");
            Console.WriteLine(Esami.StampaElenco());

            Console.WriteLine("Media tot: "+Esami.MediaEsami());

            Console.WriteLine(string.Join("\n",Esami.Graduatoria()));


        }
    }
}
