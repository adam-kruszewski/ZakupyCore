using Kruchy.Zakupy.Dao.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kruchy.Zakupy.Dao.Context
{
    public class ZakupyContext : DbContext
    {
        public DbSet<UzytkownikEntity> Uzytkownicy { get; set; }

        public DbSet<DefinicjaZamowienia> DefinicjeZamowienia { get; set; }

        public DbSet<GrupaProduktow> GrupyProduktow { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=zakupy.db");
            //optionsBuilder.UseSqlServer(
            //    @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
            //optionsBuilder.UseSqlServer
        }
    }

    public class UzytkownikEntity
    {
        public int ID { get; set; }

        public string Nazwa { get; set; }

        public string Haslo { get; set; }

        public string Email { get; set; }
    }
}
