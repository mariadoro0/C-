// Simulare il lancio di un dado a 6 facce per n volte
//Calcolare la frequenza delle uscite
// non usare gli array
using Microsoft.VisualBasic;

Console.WriteLine("Frequenza di lancio dadi!");

//input
string msg = "";
int n;
do
{
    Console.Write("Quanti lanci vuoi fare?  ");
    n = int.Parse(Console.ReadLine());

    if (n <= 0)
        Console.WriteLine("Dato inserito non valido.");

} while (n <= 0);



//lanci
int cnt1, cnt2, cnt3, cnt4, cnt5, cnt6;
cnt1 = cnt2 = cnt3 = cnt4 = cnt5 = cnt6 = 0;
Random r = new Random();
for (int i=0; i < n; i++)
{
    int lancio = r.Next(1, 7);
    if (lancio == 1) cnt1++;
    else if (lancio == 2) cnt2++;
    else if (lancio == 3) cnt3++;
    else if (lancio == 4) cnt4++;
    else if (lancio == 5) cnt5++;
    else if (lancio == 6) cnt6++;
    
}

// calcolo percentuali

msg = 
    $"Percentuale di uscita di 1: {(double)cnt1 * 100 / n:0.00}% (uscito {cnt1} volte).\n" +
    $"Percentuale di uscita di 2: {(double)cnt2 * 100 / n:0.00}% (uscito {cnt2} volte).\n" +
    $"Percentuale di uscita di 3: {(double)cnt3 * 100 / n:0.00}% (uscito {cnt3} volte).\n" +
    $"Percentuale di uscita di 4: {(double)cnt4 * 100 / n:0.00}% (uscito {cnt4} volte).\n" +
    $"Percentuale di uscita di 5: {(double)cnt5 * 100 / n:0.00}% (uscito {cnt5} volte).\n" +
    $"Percentuale di uscita di 6: {(double)cnt6 * 100 / n:0.00}% (uscito {cnt6} volte).\n";

Console.WriteLine(msg);