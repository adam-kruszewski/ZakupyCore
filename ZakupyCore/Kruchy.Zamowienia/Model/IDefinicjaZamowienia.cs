using System;

namespace Kruchy.Zamowienia.Model
{
    public interface IDefinicjaZamowienia
    {
        int ID { get; }

        string Nazwa { get; }

        DateTime DataKoncaZamawiania { get; }
    }
}