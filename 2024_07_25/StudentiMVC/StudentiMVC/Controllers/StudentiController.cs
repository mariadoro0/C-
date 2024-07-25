using Microsoft.AspNetCore.Mvc;
using StudentiMVC.Models;

namespace StudentiMVC.Controllers
{
    public class StudentiController : Controller
    {
        static List<Studente> elenco = new List<Studente>() {

        new Studente{ Matricola=12345,Cognome="Di Luigi", Nome="Stefano", Email="ppp@itis.net",Classe="1A" },

        new Studente{ Matricola=12346,Cognome="Di Giuseppe", Nome="Giuseppe", Email="pp1@itis.net",Classe="2A" },

        new Studente{ Matricola=12347,Cognome="Di Stena", Nome="Liugi", Email="pp2@itis.net",Classe="3B" },

        new Studente{ Matricola=12348,Cognome="Di Luca", Nome="Angela", Email="pp3@itis.net",Classe="4C" },

        new Studente{ Matricola=12349,Cognome="Di Dennis", Nome="Laura", Email="pp4@itis.net",Classe="5D" }

    };
        public IActionResult Index()
        {
            return View(elenco);
        }

        public IActionResult Details(int matricola)
        {
            var studente = elenco.Where(x => x.Matricola == matricola).FirstOrDefault();
            if (studente == null)
            {
                return NotFound();
            }
            else
            {
                return View(studente);
            }
        }

        //GET: creo nuovo studente
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Studente());
        }

        //POST: salvo lo studente nella lista
        [HttpPost]
        public IActionResult Create(Studente studente)
        {
            //controllo che non sia stato già inserito uno studente con la stessa matricola
            var stud = elenco.Where(x => x.Matricola == studente.Matricola).FirstOrDefault();
            if (stud == null)
            {
                elenco.Add(studente);
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        //GET: edit dei dati di uno studente
        [HttpGet]
        public IActionResult Edit(int matricola)
        {
            var studente = elenco.Where(x => x.Matricola == matricola).FirstOrDefault();
            if (studente == null)
            {
                return NotFound();

            }
            else
            {
                return View(studente);
            }
        }

        [HttpPost]
        public IActionResult Edit(Studente studente)
        {
            if (studente == null)
            {
                return NotFound();
            }

            for (int i = 0; i < elenco.Count; i++)
            {
                if (elenco[i].Matricola == studente.Matricola)
                {
                    elenco[i] = studente;
                }

            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int matricola)
        {
            var studente = elenco.Where(x => x.Matricola == matricola).FirstOrDefault();
            if (studente == null)
            {
                return NotFound();

            }
            else
            {
                return View(studente);
            }

        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int matricola)
        {
            var studente = elenco.Where(x => x.Matricola == matricola).FirstOrDefault();
            if (studente == null)
            {
                return NotFound();

            }
            else
            {
                elenco.Remove(studente);
                return RedirectToAction("Index");
            }
        }
    }
}
