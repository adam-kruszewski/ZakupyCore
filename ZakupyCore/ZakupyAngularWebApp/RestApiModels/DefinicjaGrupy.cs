using System.Collections.Generic;

namespace ZakupyAngularWebApp.RestApiModels
{
    public class DefinicjaGrupy
    {
        public string Nazwa { get; set; }

        public int? Limit { get; set; }

        public List<DefinicjaProduktu> Produkty { get; set; }

        public DefinicjaGrupy()
        {
            Produkty = new List<DefinicjaProduktu>();
        }
    }
}