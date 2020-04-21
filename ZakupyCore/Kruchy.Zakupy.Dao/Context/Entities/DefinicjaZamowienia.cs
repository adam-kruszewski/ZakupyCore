using System;

namespace Kruchy.Zakupy.Dao.Context.Entities
{
    public class DefinicjaZamowienia
    {
        public int ID { get; set; }

        public string Nazwa { get; set; }

        public DateTime DataKoncaZamawiania { get; set; }
    }
}
