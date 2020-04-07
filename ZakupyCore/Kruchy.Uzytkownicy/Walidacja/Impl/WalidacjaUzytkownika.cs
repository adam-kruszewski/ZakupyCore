using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Dao;

namespace Kruchy.Uzytkownicy.Walidacja.Impl
{
    class WalidacjaUzytkownika : IWalidacjaUzytkownika
    {
        private readonly IUzytkownikDao uzytkownikDao;

        public WalidacjaUzytkownika(
            IUzytkownikDao uzytkownikDao)
        {
            this.uzytkownikDao = uzytkownikDao;
        }

        public bool Waliduj(IUzytkownik uzytkownik, IWalidacjaListener listener)
        {
            return
                new ZbiorRegulWalidacji()
                    .DodajReguleBledu(
                        () => IstniejeWgNazwy(uzytkownik.Nazwa, uzytkownik.ID),
                        "Użytkownik o takiej nazwie już istnieje",
                        "Nazwa")
                    .Wykonaj(listener);
        }

        private bool IstniejeWgNazwy(string nazwa, int id)
        {
            var uzytkownik = uzytkownikDao.SzukajWgNazwy(nazwa);
            return uzytkownik != null && uzytkownik.ID != id;
        }
    }
}
