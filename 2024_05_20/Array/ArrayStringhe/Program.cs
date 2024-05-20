// Stampare i dati di un array precaricato 
Console.WriteLine("Array di stringhe!");

string[] nomi = { "Giulia", "Pietro", "Antonio", "Ilaria", "Andrea", "Mattia", "Matteo" };

for (int i = 0; i < nomi.Length; i++){
    Console.WriteLine($"{i + 1} : {nomi[i]}");
}
