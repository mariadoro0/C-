namespace EFCodeFirst.Models
{
    public class Prodotto
    {
        public int Id { get; set; }
        public string Denominazione { get; set; }
        public string? Descrizione { get; set; }
        public double Prezzo { get; set; }
        public int Giacenza { get; set; }
    }
}
