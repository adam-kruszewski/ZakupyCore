﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Kruchy.Zakupy.Dao.Context
{
    public class ZakupyContext : DbContext
    {
        public DbSet<UzytkownikEntity> Uzytkownicy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=blogging.db");
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
    }
}
