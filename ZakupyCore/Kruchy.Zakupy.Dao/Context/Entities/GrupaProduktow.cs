using System.Collections.Generic;

namespace Kruchy.Zakupy.Dao.Context.Entities
{
    public class GrupaProduktow
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public int? Limit { get; set; }

        public int DefinicjaZamowieniaId { get; set; }

        public List<Produkt> Produkty { get; set; }
    }
}