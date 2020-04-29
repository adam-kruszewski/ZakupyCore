using Kruchy.Zamowienia.Model;

namespace Kruchy.Zamowienia.Services
{
    public interface IDefinicjeZamowienService
    {
        int? Wstaw(WstawienieDefinicjiZamowieniaRequest request);
    }
}
