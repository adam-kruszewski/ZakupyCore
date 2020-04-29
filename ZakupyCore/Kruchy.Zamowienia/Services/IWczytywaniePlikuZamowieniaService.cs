using Kruchy.Zamowienia.Model.PlikZamowienia;

namespace Kruchy.Zamowienia.Services
{
    public interface IWczytywaniePlikuZamowieniaService
    {
        Zamowienie Wczytaj(byte[] zawartoscPliku);
    }
}