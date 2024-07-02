namespace VenditaProdotti
{
    /*
     * Esercizio 1 - VenditaProdotti

Un commerciante vende prodotti alimentari e non alimentari. 

Di ogni prodotto si conosce un codice numerico, il nome, il prezzo, la data di produzione. 

Se il prodotto è alimentare allora deve essere presente la data di scadenza, mentre se non è un prodotto alimentare si conosce la percentuale di materiale principale con il quale è costruito.

Realizzare le classi necessarie per gestire un elenco di prodotti.

Creare un menu testuale per rispondere alle seguenti richieste:

visualizzare l'elenco dei prodotti
visualizzare l'elenco dei prodotti in scadenza (minore di 10 giorni)
visualizzare l'elenco delle materie prime con cui è fatto il prodotto
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vendita Prodotti!");

            ProdottiBiz biz = new ProdottiBiz();
            biz.prodotti = new Prodotto[]
            {
                new ProdottoAlimentare {Id=1,Name="Latte",Price=0.99,Date=new DateTime(2024,1,1,0,0,0), Expiration=new DateTime(2024,6,28,0,0,0)},
                new ProdottoAlimentare {Id=2,Name="Pane",Price=1.20,Date=new DateTime(2024,6,24,0,0,0), Expiration =new DateTime(2024,6,29,0,0,0)},
                new ProdottoAlimentare {Id=3,Name="Uova",Price=2.50, Date=new DateTime(2024,6,12,0,0,0), Expiration=new DateTime(2024,7,12,0,0,0)},
                new ProdottoNonAlimentare {Id=4, Name="Calze", Price=5.00, Date=new DateTime(2024,1,4,0,0,0), MadeOf={new Composizione{Materiale="Plastica",Percentage=100} },
        }
    }
}
