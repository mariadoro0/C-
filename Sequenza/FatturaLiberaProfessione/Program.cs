//imponibile 1000 euro, a cui va applicato il calcolo dell'iva
//totale lordo = imponibile + iva
//ritenuta d'acconto = 20% imponibile
// da totale lordo togliere ritenuta d'acconto

//input
Console.Write("Inserire l'imponibile: ");
double imponibile = double.Parse(Console.ReadLine());
double ivaPerc = 22;
double ritenutaPerc = 20;

//calcoli
double iva = ivaPerc / 100;
double ritenuta = ritenutaPerc / 100;
double calcoloIva = imponibile * iva;
double totLordo = imponibile + calcoloIva;
double calcoloRit = imponibile * ritenuta;
double totNetto = totLordo - calcoloRit;

//output
Console.WriteLine("-----------------");
string msg = $"Imponibile: {imponibile:0.00} euro.\n" +
    $"IVA totale  ({ivaPerc}%): {calcoloIva:0.00} euro\n" +
    $"Ritenuta d'acconto  ({ritenutaPerc}%): {calcoloRit:0.00} euro.\n" +
    $"Totale lordo: {totLordo:0.00} euro.\n" +
    $"Totale netto: {totNetto:0.00} euro.";
Console.WriteLine(msg);
Console.WriteLine("-----------------");
