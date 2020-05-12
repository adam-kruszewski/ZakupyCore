using System;
using System.Collections.Generic;
using System.Linq;
using Kruchy.Zamowienia.Model;
using Kruchy.Zamowienia.Services;
using Microsoft.AspNetCore.Mvc;
using ZakupyAngularWebApp.Authentication;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    [WymagaLogowaniaTokenem]
    public class ZamowieniaController : Controller
    {
        private readonly IDefinicjeZamowienService definicjeZamowienService;

        public ZamowieniaController(
            IDefinicjeZamowienService definicjeZamowienService)
        {
            this.definicjeZamowienService = definicjeZamowienService;
        }

        [HttpGet]
        public IList<DefinicjaZamowienia> Szukaj()
        {
            var definicje = definicjeZamowienService.Szukaj();

            return definicje.Select(o => new DefinicjaZamowienia(o)).ToList();
        }
    }

    public class DefinicjaZamowienia
    {
        public DefinicjaZamowienia() { }

        public DefinicjaZamowienia(IDefinicjaZamowienia definicja)
        {
            ID = definicja.ID;
            Nazwa = definicja.Nazwa;
            DataKonca = definicja.DataKoncaZamawiania;
        }

        public int ID { get; set; }

        public string Nazwa { get; set; }

        public DateTime DataKonca { get; set; }
    }
}
