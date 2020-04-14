using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ZamowieniaController : Controller
    {
        public IList<DefinicjaZamowienia> Szukaj()
        {
            var definicje = new List<DefinicjaZamowienia>();

            var ile = 5 + new Random().Next(0, 10);

            for (int i = 0; i < ile; i++)
                definicje.Add(new DefinicjaZamowienia
                {
                    Nazwa = "Zamówienie " + i,
                    DataKonca = DateTime.Today.AddDays(i)
                });

            return definicje;
        }
    }

    public class DefinicjaZamowienia
    {
        public string Nazwa { get; set; }

        public DateTime DataKonca { get; set; }
    }
}
