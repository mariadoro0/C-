// Somma di due numeri interi dati in input

// input
Console.WriteLine("Somma di due numeri interi");
int a, b;

Console.Write("a: ");
string tmp = Console.ReadLine();    //Legge l'input sempre come stringhe
a = int.Parse(tmp);                 //il metodo Parse converte la stringa in numero

Console.Write("b: ");
tmp = Console.ReadLine();
b = int.Parse(tmp);

//calcolo
int c = a + b;

//output
Console.WriteLine("Somma: "+c);         //come in Java, si concatena con il '+'
Console.WriteLine("Somma: {0}", c);     //si può usare la virgola concatenando utilizzando le graffe e la posizione della variabile (segnaposto)
Console.WriteLine(a + "+" + b + "=" + c);       //sintassi di Java
Console.WriteLine("{0}+{1}={2}", a, b , c);     //sintassi C# con segnaposto
Console.WriteLine($"{a}+{b}={c}");          //forma definitiva, con il dollaro si assegnano i valori
