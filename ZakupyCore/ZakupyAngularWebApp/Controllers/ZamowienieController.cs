using System;
using Kruchy.Zamowienia.Model;
using Kruchy.Zamowienia.Services;
using Microsoft.AspNetCore.Mvc;
using ZakupyAngularWebApp.Authentication;
using ZakupyAngularWebApp.Services;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    [WymagaLogowania]
    public class ZamowienieController : Controller
    {
        private readonly IDefinicjeZamowienService definicjeService;
        private readonly IUploadedFilesService uploadedFilesService;

        public ZamowienieController(
            IDefinicjeZamowienService definicjeService,
            IUploadedFilesService uploadedFilesService)
        {
            this.definicjeService = definicjeService;
            this.uploadedFilesService = uploadedFilesService;
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
            var wstawionaID = definicjeService.Wstaw(DajRequestWstawienia(request));

            if (wstawionaID.HasValue)
                return new DodanieZamowieniaResult
                {
                    Sukces = true,
                    ID = wstawionaID.Value
                };
            else
                return new DodanieZamowieniaResult
                {
                    Sukces = false
                };
        }

        private WstawienieDefinicjiZamowieniaRequest DajRequestWstawienia(DodawanieZamowowieniaRequest request)
        {
            return new WstawienieDefinicjiZamowieniaRequest
            {
                Nazwa = request.Nazwa,
                DataKoncaZamawiania = request.DataKoncaZamawiania,
                ZawartoscPliku = uploadedFilesService.GetFile(request.KluczPliku)
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

        public string KluczPliku { get; set; }
    }

    public class DodanieZamowieniaResult
    {
        public bool Sukces { get; set; }

        public int ID { get; set; }
    }
}
