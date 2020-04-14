using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Services.Impl;
using Kruchy.Uzytkownicy.Walidacja;
using Kruchy.Uzytkownicy.Walidacja.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Kruchy.Uzytkownicy
{
    public class KruchyUzytkownicyModule
    {
        public void Init(IServiceCollection services)
        {
            services.AddTransient<IWalidacjaUzytkownika, WalidacjaUzytkownika>();
            services.AddTransient<IUzytkownicyService, UzytkownicyService>();
        }
    }
}
