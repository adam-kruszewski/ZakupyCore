using System.Collections.Generic;

namespace Kruchy.Zamowienia.Model
{
    public interface IGrupaProduktow
    {
        public string Nazwa { get; }

        public int? Limit { get; }

        public int DefinicjaZamowieniaId { get; }

        public IEnumerable<IProdukt> Produkty { get; }
    }
}