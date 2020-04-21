using System;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zamowienia.Model;

namespace Kruchy.Zamowienia.Walidacja.Impl
{
    class WalidacjaDefinicjiZamowienia : IWalidacjaDefinicjiZamowienia
    {
        public bool Waliduj(IDefinicjaZamowienia definicja, IWalidacjaListener listener)
        {
            var zbiorRegul = new ZbiorRegulWalidacji()
                .DodajReguleBledu(
                    () => definicja.DataKoncaZamawiania >= DateTime.Today,
                    "Data końca zamawiania nie może być z przeszłości", null);

            return zbiorRegul.Wykonaj(listener);
        }
    }
}