using Microsoft.AspNetCore.Mvc;
using MVCVuoto.Models;

namespace MVCVuoto.Controllers
{
    public class ProdottiController : Controller
    {
        public IActionResult Index()
        {
            var prodotto = new Prodotto { Id = 1, Name = "Prodotto 1", Price = 10.50, Date = DateTime.Parse("12/05/2024") };
            return View(prodotto);
        }
    }
}
