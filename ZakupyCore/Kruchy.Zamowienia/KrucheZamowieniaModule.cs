using Kruchy.Zamowienia.Services;
using Kruchy.Zamowienia.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Kruchy.Zamowienia
{
    public class KrucheZamowieniaModule 
    {
        public void Init(IServiceCollection services)
        {
            services.AddTransient<IDefinicjeZamowienService, DefinicjeZamowienService>();
        }
    }
}