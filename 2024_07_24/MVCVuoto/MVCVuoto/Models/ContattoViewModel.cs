namespace MVCVuoto.Models
{
    public class ContattoViewModel
    {
        public string? Cognome { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public string? Oggetto { get; set; }
        public string? Messaggio { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Cognome)}={Cognome}, {nameof(Nome)}={Nome}, {nameof(Email)}={Email}, {nameof(Oggetto)}={Oggetto}, {nameof(Messaggio)}={Messaggio}}}";
        }
    }
}
