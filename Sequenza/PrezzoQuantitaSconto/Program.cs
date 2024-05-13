// Dati in input il prezzo, la quantità e la percentuale di sconto di un prodotto
//calcolare il totale non scontato, lo sconto effettuato e il totale scontato
//visualizzare tutti i risultati
/* es. 
 * prezzo: 10
 * quantità: 3
 * percentuale di sconto: 30
 * 
 * totale: 30 euro
 * sconto effettuato: 9 euro 
 * totale scontato: 21 euro */

Console.WriteLine("Prezzo, quantità e sconto :) !");

//input
Console.Write("Inserire il prezzo: ");
double price = double.Parse(Console.ReadLine());
Console.Write("Inserire la quantità: ");
int qnt = int.Parse(Console.ReadLine());
Console.Write("Inserire il prezzo: ");
int sconto = int.Parse(Console.ReadLine());

//operazioni
double tot = price * qnt;
double scontoEff = (tot * sconto) / 100;
double totScont = tot - scontoEff;

//Output
string msg = $"" +
    $"Totale non scontato: {tot:#.##} euro.\n" +                    // il ':#.##' da un format per la stampa: stamperà solo due cifre decimali
    $"Sconto effettuato: {scontoEff:#.##} euro.\n" + 
    $"Totale scontato: {totScont:#.##} euro.";

Console.WriteLine(msg);


