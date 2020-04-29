using System;
using System.Collections.Generic;

namespace Kruchy.Zakupy.Dao.Context.Entities
{
    public class DefinicjaZamowienia
    {
        public int ID { get; set; }

        public string Nazwa { get; set; }

        public DateTime DataKoncaZamawiania { get; set; }

        public List<GrupaProduktow> GrupyProduktow { get; set; }
    }
}
