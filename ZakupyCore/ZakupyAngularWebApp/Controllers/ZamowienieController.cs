using System;
using Kruchy.Zamowienia.Model;
using Kruchy.Zamowienia.Services;
using Microsoft.AspNetCore.Mvc;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ZamowienieController : Controller
    {
        private readonly IDefinicjeZamowienService definicjeService;

        public ZamowienieController(
            IDefinicjeZamowienService definicjeService)
        {
            this.definicjeService = definicjeService;
        }

        [HttpGet]
        public DefinicjaZamowienia Get(int id)
        {
            return new DefinicjaZamowienia
            {
                ID = id,
                Nazwa = "Zamówienie do szczegółów",
                DataKonca = DateTime.Now.AddDays(2)
            };
        }

        [HttpPost]
        public DodanieZamowieniaResult Post([FromBody] DodawanieZamowowieniaRequest request)
        {
            return new DodanieZamowieniaResult
            {
                Sukces = true,
                ID = 2016
            };
        }

        [HttpPut]
        public DodanieZamowieniaResult Put([FromBody] DodawanieZamowowieniaRequest request)
        {
            var wstawionaID = definicjeService.Wstaw(
                new Definicja
                {
                    Nazwa = request.Nazwa,
                    DataKoncaZamawiania = request.DataKoncaZamawiania
                });

            return new DodanieZamowieniaResult
            {
                Sukces = true,
                ID = wstawionaID.Value
            };
        }

        private class Definicja : IDefinicjaZamowienia
        {
            public int ID { get; set; }

            public string Nazwa { get; set; }

            public DateTime DataKoncaZamawiania { get; set; }
        }
    }

    public class DodawanieZamowowieniaRequest
    {
        public string Nazwa { get; set; }

        public DateTime DataKoncaZamawiania { get; set; }
    }

    public class DodanieZamowieniaResult
    {
        public bool Sukces { get; set; }

        public int ID { get; set; }
    }
}
