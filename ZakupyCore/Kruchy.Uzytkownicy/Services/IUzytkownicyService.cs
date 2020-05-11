using System.Collections.Generic;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Views;

namespace Kruchy.Uzytkownicy.Services
{
    public interface IUzytkownicyService
    {
        UzytkownikView DajWgID(int id);

        UzytkownikView SzukajWgNazwyLubEmailaHasla(string nazwa, string haslo);

        int? Dodaj(
            DodanieUzytkownikaRequest request,
            IWalidacjaListener listener);

        bool Zmien(
            ModyfikacjaUzytkownikaRequest request,
            IWalidacjaListener listener);

        bool ZmienHaslo(
            int uzytkownikID,
            string noweHaslo,
            string noweHasloPowtorzenie,
            IWalidacjaListener listener);

        IList<UzytkownikView> SzukajWszystkich();
    }
}
