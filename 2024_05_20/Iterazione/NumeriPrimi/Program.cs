// Verificare se un numero intero è primo 
Console.WriteLine("Numeri Primi!");
Console.Write("Inserire un numero: ");
int n = int.Parse(Console.ReadLine());

//ciclo for
bool primo = true;
for (int i = 2; i < n/2; i++)
{
    if (n % i == 0)
    {
        primo = false;
        break;
    }
}

if (primo)
{
    Console.WriteLine($"Il numero {n} è un numero primo");
} else
{
    Console.WriteLine($"Il numero {n} non è un numero primo");
}
