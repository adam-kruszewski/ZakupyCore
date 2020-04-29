using Kruchy.Zamowienia.Model;

namespace Kruchy.Zamowienia.Dao
{
    public interface IGrupaProduktowDao
    {
        int? Wstaw(IGrupaProduktow grupaProduktow);
    }
}