using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Dao;

namespace Kruchy.Uzytkownicy.Walidacja
{
    public interface IWalidacjaUzytkownika
    {
        bool Waliduj(IUzytkownik uzytkownik, IWalidacjaListener listener);
    }
}