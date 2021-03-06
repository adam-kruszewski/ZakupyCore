﻿// <auto-generated />
using System;
using Kruchy.Zakupy.Dao.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kruchy.Zakupy.Dao.Migrations
{
    [DbContext(typeof(ZakupyContext))]
    [Migration("20200429120135_ChangeProductTableName")]
    partial class ChangeProductTableName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Kruchy.Zakupy.Dao.Context.Entities.DefinicjaZamowienia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataKoncaZamawiania")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nazwa")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("DefinicjeZamowienia");
                });

            modelBuilder.Entity("Kruchy.Zakupy.Dao.Context.Entities.GrupaProduktow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DefinicjaZamowieniaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Limit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nazwa")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DefinicjaZamowieniaId");

                    b.ToTable("GrupyProduktow");
                });

            modelBuilder.Entity("Kruchy.Zakupy.Dao.Context.Entities.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cena")
                        .HasColumnType("TEXT");

                    b.Property<int>("GrupaProduktowId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nazwa")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumerWierszaWExcelu")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GrupaProduktowId");

                    b.ToTable("Produkty");
                });

            modelBuilder.Entity("Kruchy.Zakupy.Dao.Context.UzytkownikEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Haslo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nazwa")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Uzytkownicy");
                });

            modelBuilder.Entity("Kruchy.Zakupy.Dao.Context.Entities.GrupaProduktow", b =>
                {
                    b.HasOne("Kruchy.Zakupy.Dao.Context.Entities.DefinicjaZamowienia", null)
                        .WithMany("GrupyProduktow")
                        .HasForeignKey("DefinicjaZamowieniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kruchy.Zakupy.Dao.Context.Entities.Produkt", b =>
                {
                    b.HasOne("Kruchy.Zakupy.Dao.Context.Entities.GrupaProduktow", null)
                        .WithMany("Produkty")
                        .HasForeignKey("GrupaProduktowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
