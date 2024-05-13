// Dati in input 2 numeri interi, calcolare il quoziente intero, il resto e il quoziente reale e visualizzare i risultati

//input
Console.WriteLine("Inserisci due numeri: ");
Console.Write("Dividendo: ");
int n1 = int.Parse(Console.ReadLine());
Console.Write("Divisore: ");
int n2 = int.Parse(Console.ReadLine());

// operazioni
float qreale = (float) n1 / (float) n2;             //casting: solo per questa operazione, considera n1 ed n2 come float
int qint = n1 / n2;
int qresto = n1 % n2;


Console.WriteLine($"Quoziente reale: {qreale}\nQuoziente intero: {qint}\nResto della divisione: {qresto}");

//l'output si può formattare con una stringa in questo modo (fromat di stampa-dettaglio)
string msg = $"" +
    $"\nQuoziente intero: {qint}" +
    $"\nResto: {qresto}"+
    $"\nQuoziente reale: {qreale}";
Console.WriteLine(msg);