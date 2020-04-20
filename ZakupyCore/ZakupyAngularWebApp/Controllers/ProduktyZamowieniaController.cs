using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZakupyAngularWebApp.RestApiModels;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProduktyZamowieniaController : Controller
    {
        [HttpGet]
        public List<DefinicjaGrupy> Get(int zamowienieID)
        {
            return SzukajGrup(zamowienieID).ToList();
        }

        private IEnumerable<DefinicjaGrupy> SzukajGrup(int zamowienieID)
        {
            yield return new DefinicjaGrupy
            {
                Nazwa = "Grupa 1 z limitem",
                Limit = 4,
                Produkty =
                new[]
                {
                    new DefinicjaProduktu {Nazwa = "Produkt 1 ", Cena = 2.34m},
                    new DefinicjaProduktu { Nazwa = "Produkt 2", Cena = 3.45m}
                }.ToList()
            };

            yield return new DefinicjaGrupy
            {
                Nazwa = "Grupa 2 bez limitu",
                Limit = null,
                Produkty =
                new[]
                {
                    new DefinicjaProduktu {Nazwa = "Produkt 3 ", Cena = 6.11m},
                    new DefinicjaProduktu { Nazwa = "Produkt 4", Cena = 7.04m}
                }.ToList()
            };
        }
    }
}
