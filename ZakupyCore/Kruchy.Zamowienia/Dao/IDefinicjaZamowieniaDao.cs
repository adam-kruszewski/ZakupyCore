using System.Collections.Generic;
using Kruchy.Zamowienia.Model;

namespace Kruchy.Zamowienia.Dao
{
    public interface IDefinicjaZamowieniaDao
    {
        int Wstaw(IDefinicjaZamowienia definicja);

        IEnumerable<IDefinicjaZamowienia> Szukaj();
    }
}