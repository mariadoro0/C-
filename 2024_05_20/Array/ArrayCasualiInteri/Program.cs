// generare un array di numeri interi casuali a dimensione casuale con le seguenti ipotesi:
//a) Dimensione array [inf,sup] con inf e sup presi in input
//b) Riempimento dell'array: [inf1,sup1] con inf1 e sup1 presi in input
//Stampare i seguenti risultati
//1. posizione e valore dei numeri multipli di m, con m da input
//2. posizione e valore dei numeri primi 
//3. media aritmetica dei soli numeri positivi
//0. esci dal programma

using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;
using System.Xml;

Console.WriteLine("Array a caso!");
Random r = new Random();

//CREAZIONE ARRAY
Console.Write("Inserire l'estremo inferiore per la dimensione: ");
int inf = int.Parse(Console.ReadLine());
Console.Write("Inserire l'estremo superiore per la dimensione: ");
int sup = int.Parse(Console.ReadLine());

int dim = r.Next(inf, sup);
int[] array = new int[dim];

//RIEMPIMENTO ARRAY
Console.Write("\nInserire l'estremo inferiore per il riempimento: ");
inf = int.Parse(Console.ReadLine());
Console.Write("Inserire l'estremo superiore per il riempimento: ");
sup = int.Parse(Console.ReadLine());

for (int i = 0; i < dim; i++)
{
    array[i] = r.Next(inf, sup);
}
Console.WriteLine("Array generato.");

Menu(array);


void StampaArray(int[] array)
{
    for(int i = 0;i < array.Length;i++)
        Console.WriteLine($"{i} ; {array[i]}");
}


void MultipliM(int[] array, int m)
{

    for (int i = 0;i < dim; i++)
    {
        if (array[i]%m == 0)
        {
            Console.WriteLine($"{i}:{array[i]}");
        }
    }

}

bool isPrimo(int n) {
    bool primo = true;
    for (int i = 2; i < n / 2; i++)
    {
        if (n % i == 0)
        {
            primo = false;
            break;
        }
    }
    return primo;
}


double MediaPositivi(int[] array)
{
    double media = 0;
    int cnt = 0;
    for (int i = 0; i < dim ; i++) { 
        if (array[i] > 0)
        {
            media = media + array[i];
            cnt++;
        }
    }
    return media/cnt;
}




void Menu(int[] array){ 
    int scelta = -1;
    do
    {
        string menu = "----------MENU' DI SCELTA--------" + "\nSeleziona l'operazione che desideri eseguire:\n" + "1) Posizione e valore dei multipli di m.\n" +
                "2) Posizione e valore dei numeri primi generati.\n" + "3) Media aritmetica dei soli numeri positivi.\n" + "4) Stampa Array\n"+"0) Uscita.";
        Console.WriteLine(menu);
        Console.Write("La tua scelta: ");
        scelta = int.Parse(Console.ReadLine());
        Console.WriteLine("-------------------------");

        switch (scelta)
        {
            case 1:
                Console.Write("Inserire il multiplo: ");
                int m = int.Parse(Console.ReadLine());
                MultipliM(array,m);
                break;
            case 2:
                Console.WriteLine("Posizione e valore dei numeri primi: ");
                for (int i = 0; i < dim; i++)
                {
                    if (isPrimo(array[i]) == true){
                        Console.WriteLine($"{i}:{array[i]}");
                    }
                }
                break;
            case 3:
                double media = MediaPositivi(array);
                Console.WriteLine("La media dei numeri positivi è: " + media);
                break;

            case 4:
                StampaArray(array);
                break;
        }




    } while (scelta!=0);
}



