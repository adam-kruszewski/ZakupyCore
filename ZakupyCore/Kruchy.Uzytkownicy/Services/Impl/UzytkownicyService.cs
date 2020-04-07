using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Dao;
using Kruchy.Uzytkownicy.Views;
using Kruchy.Uzytkownicy.Walidacja;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    public class UzytkownicyService : IUzytkownicyService
    {
        private readonly IUzytkownikDao uzytkownikDao;
        private readonly IWalidacjaUzytkownika walidacjaUzytkownika;

        public UzytkownicyService(
            IUzytkownikDao uzytkownikDao,
            IWalidacjaUzytkownika walidacjaUzytkownika)
        {
            this.uzytkownikDao = uzytkownikDao;
            this.walidacjaUzytkownika = walidacjaUzytkownika;
        }

        public UzytkownikView DajWgID(int id)
        {
            var uzytkownik = uzytkownikDao.DajWgID(id);

            return new UzytkownikView()
            {
                ID = uzytkownik.ID,
                Nazwa = uzytkownik.Nazwa,
            };
        }

        public int? Dodaj(DodanieUzytkownikaRequest request, IWalidacjaListener listener)
        {
            var entity = new Uzytkownik
            {
                Nazwa = request.Nazwa,
                Haslo = request.Haslo,
                Email = request.Email
            };

            if (!walidacjaUzytkownika.Waliduj(entity, listener))
                return null;

            return uzytkownikDao.Wstaw(entity);
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
                Email = o.Email
            }).ToList();
        }

        public bool Zmien(
            ModyfikacjaUzytkownikaRequest request,
            IWalidacjaListener listener)
        {
            var entity = new Uzytkownik
            {
                ID = request.ID,
                Nazwa = request.Nazwa,
                Haslo = request.Haslo,
                Email = request.Email
            };

            if (!walidacjaUzytkownika.Waliduj(entity, listener))
                return false;

            uzytkownikDao.Aktualizuj(entity);

            return true;
        }

        public bool ZmienHaslo(
            int uzytkownikID,
            string noweHaslo,
            string noweHasloPowtorzenie,
            IWalidacjaListener listener)
        {
            throw new NotImplementedException();

        }

        private class Uzytkownik : IUzytkownik
        {
            public int ID { get; set; }

            public string Nazwa { get; set; }

            public string Haslo { get; set; }

            public string Email { get; set; }
        }
    }
}
