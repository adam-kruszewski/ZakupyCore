using System;
using Kruchy.Zakupy.Dao.Context;
using Kruchy.Zakupy.Dao.Context.Entities;
using Kruchy.Zamowienia.Dao;
using Kruchy.Zamowienia.Model;

namespace Kruchy.Zakupy.Dao.Dao
{
    class GrupaProduktowDao : IGrupaProduktowDao
    {
        private readonly ZakupyContext context;

        public GrupaProduktowDao(
            ZakupyContext context)
        {
            this.context = context;
        }

        public int? Wstaw(IGrupaProduktow grupaProduktow)
        {
            var grupaEntity = new GrupaProduktow
            {
                DefinicjaZamowieniaId = grupaProduktow.DefinicjaZamowieniaId,
                Limit = grupaProduktow.Limit,
                Nazwa = grupaProduktow.Nazwa,
            };

            context.GrupyProduktow.Add(grupaEntity);
            context.SaveChanges();

            foreach (var produkt in grupaProduktow.Produkty)
            {
                var produktEntity = new Produkt
                {
                    GrupaProduktowId = grupaEntity.Id,
                    Nazwa = produkt.Nazwa,
                    Cena = produkt.Cena,
                    NumerWierszaWExcelu = produkt.NumerWierszaWExcelu
                };
                context.Produkty.Add(produktEntity);
            }

            context.SaveChanges();
            return grupaEntity.Id;
        }
    }
}
