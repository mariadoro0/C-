// inserire e stampare un elenco di numeri interi 
// usare gli array
Console.WriteLine("Array di numeri interi!");

Console.Write("Inserire quanti numeri si vogliono caricare:  ");
int n = int.Parse(Console.ReadLine()); 

//inizializzazione di un array di numeri interi
int[] numeri = new int[n];


Console.WriteLine("Inserire i numeri da caricare nell'array: ");
for (int i = 0; i < numeri.Length; i++)
{
    Console.Write($"Numero {i+1}: ");
    numeri[i] = int.Parse(Console.ReadLine()) ;
}

Console.WriteLine("------Stampa dell'array-------");

for (int i = 0;i < numeri.Length;i++)
{
    Console.WriteLine($"{i + 1} : {numeri[i]}");
}
