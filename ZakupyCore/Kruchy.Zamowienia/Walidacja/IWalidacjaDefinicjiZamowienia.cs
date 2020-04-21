using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zamowienia.Model;

namespace Kruchy.Zamowienia.Walidacja
{
    interface IWalidacjaDefinicjiZamowienia
    {
        bool Waliduj(IDefinicjaZamowienia definicja, IWalidacjaListener listener);
    }
}