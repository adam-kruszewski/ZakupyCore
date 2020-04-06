using System;
using System.Linq;
using Kruchy.Uzytkownicy.Dao;
using Kruchy.Zakupy.Dao.Context;
using Kruchy.Zakupy.Dao.Dao;
using Microsoft.Extensions.DependencyInjection;

namespace Kruchy.Zakupy.Dao
{
    public class KruchyZakupyDaoModule
    {
        public void Init(IServiceCollection services)
        {
            using (var context = new ZakupyContext())
            {
                var creationResult = context.Database.EnsureCreated();

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
            services.AddDbContext<ZakupyContext>();
        }
    }
}