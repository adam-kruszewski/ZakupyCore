using System.Collections.Generic;
using System.Linq;
using Kruchy.Uzytkownicy.Dao;
using Kruchy.Zakupy.Dao.Context;

namespace Kruchy.Zakupy.Dao.Dao
{
    class UzytkownikDao : IUzytkownikDao
    {
        private readonly ZakupyContext zakupyContext;
        private static int Sekwencja = 10;

        private readonly int id;

        public UzytkownikDao(
            ZakupyContext zakupyContext)
        {
            id = Sekwencja;
            Sekwencja++;
            this.zakupyContext = zakupyContext;
        }

        public IUzytkownik DajWgID(int id)
        {
            var uzytkownikEntity = zakupyContext.Uzytkownicy.Single(o => o.ID == id);

            return new Uzytkownik
            {
                ID = uzytkownikEntity.ID,
                Nazwa = uzytkownikEntity.Nazwa,
                Haslo = uzytkownikEntity.Haslo,
                Email = uzytkownikEntity.Email
            };
        }

        public IEnumerable<IUzytkownik> Szukaj()
        {
            return
                zakupyContext.Uzytkownicy.Select(o => new Uzytkownik
                {
                    ID = o.ID,
                    Nazwa = o.Nazwa,
                    Haslo = o.Haslo,
                    Email = o.Email
                });
        }

        public int Wstaw(IUzytkownik uzytkownik)
        {
            var uzytkownikEntity = new UzytkownikEntity
            {
                Nazwa = uzytkownik.Nazwa,
                Haslo = uzytkownik.Haslo,
                Email = uzytkownik.Email
            };

            zakupyContext.Uzytkownicy.Add(uzytkownikEntity);
            zakupyContext.SaveChanges();

            return uzytkownikEntity.ID;
        }

        public void Aktualizuj(IUzytkownik uzytkownik)
        {
            var uzytkownikEntity =
                zakupyContext.Uzytkownicy.Single(o => o.ID == uzytkownik.ID);

            uzytkownikEntity.Nazwa = uzytkownik.Nazwa;
            uzytkownikEntity.Haslo = uzytkownik.Haslo;
            uzytkownikEntity.Email = uzytkownik.Email;

            zakupyContext.SaveChanges();
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
