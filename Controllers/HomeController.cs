using JMGB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JMGB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ValidateJMBG(string ime, string prezime, string jmbg)
        {
            if (!IsValidJMBG(jmbg))
            {
                return Json(new { valid = false, message = "JMBG je nevalidan." });
            }

            var birthDate = $"{jmbg.Substring(0, 2)}.{jmbg.Substring(2, 4)}.{jmbg.Substring(4, 7)}";
            var region = jmbg.Substring(8, 10);
            var genderCode = int.Parse(jmbg.Substring(10, 13));
            var gender = genderCode < 500 ? "Muški" : "Ženski";

            var data = new
            {
                Ime = ime,
                Prezime = prezime,
                DatumRodjenja = birthDate,
                Regija = region,
                Pol = gender
            };

            return Json(new { valid = true, data });
        }

        private bool IsValidJMBG(string jmbg)
        {
            // Validacija JMBG-a prema pravilima
            if (jmbg.Length != 13 || !jmbg.All(char.IsDigit))
            {
                return false;
            }

            // Provera kontrolne cifre
            // (Koristi isti algoritam kao u JavaScriptu za validaciju)
            // Ovaj deo možete implementirati prema potrebama
            return true;
        }

    }
}
