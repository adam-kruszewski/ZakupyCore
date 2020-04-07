using System;
using System.Collections.Generic;
using System.Text;

namespace Kruchy.Uzytkownicy.Dao
{
    public interface IUzytkownikDao
    {
        IUzytkownik DajWgID(int id);

        IEnumerable<IUzytkownik> Szukaj();

        int Wstaw(IUzytkownik uzytkownik);

        void Aktualizuj(IUzytkownik uzytkownik);
    }

    public interface IUzytkownik
    {
        int ID { get; }

        string Nazwa { get; }

        string Haslo { get; }

        string Email { get; }
    }
}
