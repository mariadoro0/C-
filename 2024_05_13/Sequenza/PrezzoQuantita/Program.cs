//Dati in input prezzo e quantità di un prodotoo,
//calcolare il totale
//visualizzare il risultato

//input
Console.Write("Inserire il prezzo dell'articolo: ");
double price = double.Parse(Console.ReadLine());        //in C# la lettura del floating point dipende dal sistema: se il software è in italiano, bisogna usare la virgola
Console.Write("Inserire la quantità: ");
int qnt = int.Parse(Console.ReadLine());

//operazioni
double totprice = price * qnt;


//output
string msg = $"\nIl prezzo totale da pagare è {totprice} euro.\n";
Console.WriteLine(msg);
