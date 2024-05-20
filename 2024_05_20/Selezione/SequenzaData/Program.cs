// Dati in input giorno, mese e anno
//restituire uno dei seguenti messaggi
//Errore | gg/mm/aaaa
using Microsoft.VisualBasic;

Console.WriteLine("Sequenza Date.");
Console.Write("Inserire il giorno: ");
int gg = int.Parse(Console.ReadLine());
Console.Write("Inserire il mese: ");
int mese = int.Parse(Console.ReadLine());
Console.Write("Inserire l'anno: ");
int anno = int.Parse(Console.ReadLine());
string messaggio = "";

if ((gg < 1 || gg > 31) || (mese < 1 || mese > 12) || (anno < 1582))
{
    messaggio = "Errore";
}
else if ((mese == 4 || mese == 6 || mese == 9 || mese == 11) && gg > 30)
    messaggio = "Errore";
else if ((mese == 2) && gg > 29)
    messaggio = "Errore";
else if (mese == 2 && (anno % 4) != 0 && gg == 29)
    messaggio = "Errore";
else if (mese == 2 && anno % 100 == 0 && anno % 400 != 0 && gg == 29)
    messaggio = "Errore";
else
{
    messaggio = $"" +
        (gg < 10 ? "0" : "") + $"{gg}/" +
        (mese < 10 ? "0" : "") + $"{mese}/{anno}";

}
Console.WriteLine(messaggio);
