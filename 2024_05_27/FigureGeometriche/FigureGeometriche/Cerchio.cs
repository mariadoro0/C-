using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureGeometriche
{
    internal class Cerchio
    {
		//proprietà
		//autocompletamento: scrivi propfull e poi doppio Tab
		private double raggio;

		public double Raggio
		{
			get { return raggio; }
			set { if (value<=0) 
					throw new Exception("Dato non valido.");
				raggio = value; }
		}


		// al costruttore passo Lato e non this.lato perchè Lato fa i controlli necessari
		// passiamo il parametro raggio per costruire il cerchio
		public Cerchio(double raggio)
		{
			Raggio = raggio;
		}

		//metodi
		public double Diametro() { return raggio*2; }
		public double Perimetro() { return Diametro()*Math.PI; }
		public double Area() {  return Math.PI*Math.Pow(Raggio,2); }

        public override string ToString()
        {
            return $"Raggio: {Raggio}"+
				$", Diametro: {Diametro()}"+
				$", Perimetro: {Perimetro()}"+
				$", Area: {Area()}";
        }

        //metodi usa e getta:
        public string StampaDettaglio()
		{
            return $"Raggio: {Raggio}" +
                $"\nDiametro: {Diametro():#.###}" +
                $"\nPerimetro: {Perimetro():#.###}" +
                $"\nArea: {Area():#.###}";
        }
    }
 
}
