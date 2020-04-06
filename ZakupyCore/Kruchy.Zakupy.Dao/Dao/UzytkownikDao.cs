using System.Collections.Generic;
using System.Linq;
using Kruchy.Uzytkownicy.Dao;
using Kruchy.Zakupy.Dao.Context;

namespace Kruchy.Zakupy.Dao.Dao
{
    class UzytkownikDao : IUzytkownikDao
    {
        private readonly ZakupyContext zakupyContext;

        public UzytkownikDao(
            ZakupyContext zakupyContext)
        {
            this.zakupyContext = zakupyContext;
        }

        public IEnumerable<IUzytkownik> Szukaj()
        {
            return
                zakupyContext.Uzytkownicy.Select(o => new Uzytkownik
                {
                    ID = o.ID,
                    Nazwa = o.Nazwa,
                    Haslo = o.Haslo
                });
        }

        private class Uzytkownik : IUzytkownik
        {
            public int ID { get; set; }

            public string Nazwa { get; set; }

            public string Haslo { get; set; }
        }
    }
}
