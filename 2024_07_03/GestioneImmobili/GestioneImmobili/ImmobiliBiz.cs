using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneImmobili
{
    internal class ImmobiliBiz
    {
        public List<Immobile> Immobili { get; set; }

        public ImmobiliBiz(List<Immobile> immobili)
        {
            Immobili = immobili;
        }

        public int ContaImmobili()
        {
            return Immobili.Count;
        }

        public string StampaImmobili()
        {
            return string.Join<Immobile>("\n", Immobili);

        }

        public List<Appartamento> FindAppartamenti()
        {
            List<Appartamento> app = new List<Appartamento>();
            foreach (var item in Immobili)
            {
                if (item is Appartamento)
                {
                    app.Add((Appartamento)item);
                }
            }
            return app;
        }
        public string StampaAppartamenti()
        {
            var app = FindAppartamenti();
            if (app.Count==0)
            {
                return "Non sono presenti appartamenti nella lista.";
            }
            else return string.Join("\n",app);
        }

        public List<Villa> FindVille()
        {
            List<Villa> ville = new List<Villa>();
            foreach (var item in Immobili)
            {
                if (item is Villa)
                {
                    ville.Add((Villa)item);
                }
            }
            return ville;
        }
        public string StampaVille()
        {
            var ville = FindVille();
            if (ville.Count==0)
            {
                return "Non sono presenti ville nella lista.";
            }
            else return string.Join("\n",ville);
        }


        public List<Box> FindBox()
        {
            List<Box> box = new List<Box>();
            foreach (var item in Immobili)
            {
                if (item is Box)
                {
                    box.Add((Box)item);
                }
            }
            return box;
        }
        public string StampaBox()
        {
            var box = FindBox();
            if (box.Count == 0)
            {
                return "Non sono presenti box nella lista";
            }
            else return string.Join("\n",box);
        }

        public string ImmobiliCitta(string citta)
        {
            List<Immobile> immobili = new List<Immobile>();
            foreach(var item in Immobili)
            {
                if(item.Citta == citta)
                {
                    immobili.Add(item);
                }
            }
            if (immobili.Count == 0)
            {
                return "Non sono presenti immobili nella città di " + citta;
            }
            else return string.Join("\n",immobili);
        }

        public string StampaDettaglioImmobile(string codice)
        {
            foreach(var item in Immobili)
            {
                if(item.Id == codice)
                {
                    return item.StampaDettaglio();
                }
            }
            return "Non è stato trovato nessun immobile corrispondente al codice inserito.";
        }
    }
}
