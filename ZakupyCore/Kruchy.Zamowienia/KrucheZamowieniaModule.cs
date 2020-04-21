using Kruchy.Zamowienia.Services;
using Kruchy.Zamowienia.Services.Impl;
using Kruchy.Zamowienia.Walidacja;
using Kruchy.Zamowienia.Walidacja.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Kruchy.Zamowienia
{
    public class KrucheZamowieniaModule 
    {
        public void Init(IServiceCollection services)
        {
            services.AddTransient<IDefinicjeZamowienService, DefinicjeZamowienService>();
            services.AddTransient<IWalidacjaDefinicjiZamowienia, WalidacjaDefinicjiZamowienia>();
        }
    }
}