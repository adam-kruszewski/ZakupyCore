using System;
using System.Collections.Generic;
using System.Text;

namespace Kruchy.Uzytkownicy.Dao
{
    public interface IUzytkownikDao
    {
        IEnumerable<IUzytkownik> Szukaj();
    }

    public interface IUzytkownik
    {
        int ID { get; }

        string Nazwa { get; }

        string Haslo { get; }
    }
}
