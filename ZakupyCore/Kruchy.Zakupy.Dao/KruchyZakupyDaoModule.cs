using System.Linq;
using Kruchy.Model.DataTypes.Database;
using Kruchy.Uzytkownicy.Dao;
using Kruchy.Zakupy.Dao.Context;
using Kruchy.Zakupy.Dao.Dao;
using Kruchy.Zakupy.Dao.Database;
using Kruchy.Zamowienia.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kruchy.Zakupy.Dao
{
    public class KruchyZakupyDaoModule
    {
        public void Init(IServiceCollection services)
        {
            using (var context = new ZakupyContext())
            {
                //var creationResult = 
                context.Database.Migrate();

                if (!context.Uzytkownicy.Any())
                {
                    var uzytkownik = new UzytkownikEntity
                    {
                        Haslo = "abc",
                        Nazwa = "user1"
                    };
                    context.Uzytkownicy.Add(uzytkownik);
                    context.SaveChanges();
                }
            }

            services.AddScoped<IUzytkownikDao, UzytkownikDao>();
            services.AddScoped<IDefinicjaZamowieniaDao, DefinicjaZamowieniaDao>();
            services.AddScoped<IGrupaProduktowDao, GrupaProduktowDao>();

            services.AddDbContext<ZakupyContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}