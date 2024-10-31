namespace Istat.Models
{
    public class RegioneViewModel
    {
        private Regione _regione;

        public RegioneViewModel(Regione regione)
        {
            _regione = regione;
        }

        public string Denominazione => _regione.Denominazione;

        public string RipartizioneGeografica => _regione.IdRipartizioneNavigation.Denominazione;

        public int NumeroProvince => _regione.Provincia.Count;

        public int NumeroComuni => _regione.Provincia.Sum(p => p.Comunes.Count);

        public double SuperficieTotale => _regione.Provincia.Sum(p => p.Comunes.Sum(c => c.Superficie));

        public double PopolazioneMedia
        {
            get
            {
                double popolazioneTotale = _regione.Provincia.Sum(p => p.Comunes.Average(c => c.Popolazione2001 + c.Popolazione2011));
                return popolazioneTotale;
            }
        }

    }
}
