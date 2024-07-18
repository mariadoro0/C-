using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doro_Esercitazione
    /*2) Venditore che eredita da Persona con

proprietà: Settore che descrive il tipo di settore vendite a cui fa capo: Auto o Moto
metodi: Tredicesima che restituisce il 91% in più dello stipendio, Clone, ToString
    */
{
    internal class Venditore : Persona, ICloneable
    {
        public SETTORE Settore { get; set; }

        public object Clone()
        {
            Venditore venditore = new Venditore(this.Nome, this.Cognome, this.Stipendio, this.Settore);
            
            return venditore;
        }

        public Venditore(string Nome, string Cognome, double Stipendio, SETTORE settore)
        {   
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.Stipendio = Stipendio;
            Settore = settore;
        }

        public override string ToString()
        {
            return base.ToString()+$"{nameof(Settore)}={ Settore.ToString()}" ;
        }

        public override double Tredicesima()
        {
            return Stipendio + ((Stipendio * 91) / 100); ;
        }


        /*tariffa giornaliera = stipendio/numgiorni*/
        public double TariffaGiornaliera(double giorniLavorati)
        {
            return Stipendio / giorniLavorati;
        }

    }
}
