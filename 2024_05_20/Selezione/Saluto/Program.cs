// Visualizzare uno dei seguenti messaggi: Buongiorno, Buon pomeriggio, Buonasera, Buonanotte, Errore
// [6-14) Buongiorno, [14-18) Nuon Pomeriggio, [18-22) Buonasera, [22-6) Buonanotte, Errore
using System.ComponentModel.Design;

Console.WriteLine("Saluti!");
Console.Write("Inserire l'ora in un formato compreso tra 0 e 23: ");
int hour = int.Parse(Console.ReadLine());

if (hour < 0 || hour > 23)
    Console.WriteLine("Input errato.");
else if (hour >= 6 && hour < 14)
    Console.WriteLine("Buongiorno!");
else if (hour >= 14 && hour < 18)
    Console.WriteLine("Buon pomeriggio!");
else if (hour >= 18 && hour < 22)
    Console.WriteLine("Buona sera!");
else  
    Console.WriteLine("Buona notte!");

