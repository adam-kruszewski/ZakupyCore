using System;
using System.Collections.Generic;
using System.Text;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Views;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    class UzytkownicyService : IUzytkownicyService
    {
        public UzytkownikView DajWgID(int id)
        {
            throw new NotImplementedException();
        }

        public int? Dodaj(DodanieUzytkownikaRequest request, IWalidacjaListener listener)
        {
            return 1;
        }

        public UzytkownikView SzukajWgNazwyHasla(string nazwa, string haslo)
        {
            throw new NotImplementedException();
        }

        public IList<UzytkownikView> SzukajWszystkich()
        {
            throw new NotImplementedException();
        }

        public bool Zmien(ModyfikacjaUzytkownikaRequest request, IWalidacjaListener listener)
        {
            throw new NotImplementedException();
        }

        public bool ZmienHaslo(int uzytkownikID, string noweHaslo, string noweHasloPowtorzenie, IWalidacjaListener listener)
        {
            throw new NotImplementedException();
        }
    }
}
