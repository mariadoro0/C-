//Dati in input ora minuti e secondi
//restituire in output uno dei seguenti messaggi:
//Errore | hh:mm:ss


using Microsoft.VisualBasic;

Console.WriteLine("Sequenza Oraria!");
Console.Write("Inserire l'ora: ");
int h = int.Parse(Console.ReadLine());
Console.Write("Inserire i minuti: ");
int m = int.Parse(Console.ReadLine());
Console.Write("Inserire i secondi: ");
int s = int.Parse(Console.ReadLine());
string msg = "";

if (h < 0 || h > 23 || m < 0 || m > 59 || s < 0 || s > 59)
{
    msg = "Errore";
}
else {
    //operatore ternario ?:
    msg = $"" +
        (h < 10 ? "0" : "") + $"{h}:"+
        (m < 10 ? "0" : "") + $"{m}:"+
        (s < 10 ? "0" : "") + $"{s}";
}
Console.WriteLine(msg);