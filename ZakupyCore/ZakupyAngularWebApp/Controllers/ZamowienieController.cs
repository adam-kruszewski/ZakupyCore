using System;
using Microsoft.AspNetCore.Mvc;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/zamowienie")]
    public class ZamowienieController : Controller
    {
        [HttpGet]
        public DefinicjaZamowienia DajWgID(int id)
        {
            return new DefinicjaZamowienia
            {
                ID = id,
                Nazwa = "Zamówienie do szczegółów",
                DataKonca = DateTime.Now.AddDays(2)
            };
        }
    }
}
