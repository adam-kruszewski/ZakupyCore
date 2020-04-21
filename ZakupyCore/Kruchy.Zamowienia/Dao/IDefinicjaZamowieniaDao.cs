using Kruchy.Zamowienia.Model;

namespace Kruchy.Zamowienia.Dao
{
    public interface IDefinicjaZamowieniaDao
    {
        int Wstaw(IDefinicjaZamowienia definicja);
    }
}