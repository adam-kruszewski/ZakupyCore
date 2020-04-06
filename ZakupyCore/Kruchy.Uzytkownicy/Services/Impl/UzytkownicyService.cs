using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Dao;
using Kruchy.Uzytkownicy.Views;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    public class UzytkownicyService : IUzytkownicyService
    {
        private readonly IUzytkownikDao uzytkownikDao;

        public UzytkownicyService(
            IUzytkownikDao uzytkownikDao)
        {
            this.uzytkownikDao = uzytkownikDao;
        }

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
            return uzytkownikDao.Szukaj().Select(o => new UzytkownikView()
            {
                ID = o.ID,
                Nazwa = o.Nazwa,
                Email = "a@b.pl"
            }).ToList();
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
