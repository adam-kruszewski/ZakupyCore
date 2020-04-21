using System;
using Microsoft.AspNetCore.Mvc;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ZamowienieController : Controller
    {
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
            return new DodanieZamowieniaResult
            {
                Sukces = true,
                ID = 2020
            };
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
