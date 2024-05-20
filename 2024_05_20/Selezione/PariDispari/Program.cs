// Dato in input un numero interos tabilire se è pari o dispari
Console.WriteLine("Pari o Dispari?");
//input
Console.Write("Inserire un numero: ");
int n = int.Parse(Console.ReadLine());
//controllo
if ((n % 2) == 0)
    Console.WriteLine("Il numero "+n+" è pari.");
 else
   Console.WriteLine("Il numero " + n + " è dispari.");

