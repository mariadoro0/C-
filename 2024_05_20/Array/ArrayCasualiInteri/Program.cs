// generare un array di numeri interi casuali a dimensione casuale con le seguenti ipotesi:
//a) Dimensione array [inf,sup] con inf e sup presi in input
//b) Riempimento dell'array: [inf1,sup1] con inf1 e sup1 presi in input
//Stampare i seguenti risultati
//1. posizione e valore dei numeri multipli di m, con m da input
//2. posizione e valore dei numeri primi 
//3. media aritmetica dei soli numeri positivi
//0. esci dal programma

using System.ComponentModel.Design;

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
Console.Write("Inserire l'estremo inferiore per la dimensione: ");
inf = int.Parse(Console.ReadLine());
Console.Write("Inserire l'estremo superiore per la dimensione: ");
sup = int.Parse(Console.ReadLine());

for (int i = 0; i < dim; i++)
{
    array[i] = r.Next(inf, sup);
}

Menu(array);



void Menu(int[] array){ 
    int scelta = -1;
    do
    {
        string menu = "----------MENU' DI SCELTA--------" + "\nSeleziona l'operazione che desideri eseguire:\n" + "1) Posizione e valore dei multipli di m.\n" +
                "2) Posizione e valore dei numeri primi generati.\n" + "3) Media aritmetica dei soli numeri positivi.\n" + "0) Uscita.";
        Console.WriteLine(menu);
        Console.Write("La tua scelta: ");
        scelta = int.Parse(Console.ReadLine());

        switch (scelta)
        {
            case 1:
                MultipliM(array);
                break;
            case 2:
                NumeriPrimi(array); 
                break;
            case 3:
                MediaPositivi(array);
                break;
        }



    } while (scelta!=0);
}


