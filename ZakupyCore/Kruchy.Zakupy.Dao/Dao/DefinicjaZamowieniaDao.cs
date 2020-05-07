using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Kruchy.Model.DataTypes.Database;
using Kruchy.Zakupy.Dao.Context;
using Kruchy.Zamowienia.Dao;
using Kruchy.Zamowienia.Model;

namespace Kruchy.Zakupy.Dao.Dao
{
    class DefinicjaZamowieniaDao : IDefinicjaZamowieniaDao
    {
        private readonly ZakupyContext zakupyContext;
        private readonly IUnitOfWork unitOfWork;

        public DefinicjaZamowieniaDao(
            ZakupyContext zakupyContext,
            IUnitOfWork unitOfWork)
        {
            this.zakupyContext = zakupyContext;
            this.unitOfWork = unitOfWork;
        }

        public int Wstaw(IDefinicjaZamowienia definicja)
        {
            using (new UsingUnitOfWork(unitOfWork))
            {
                var nowa = new Kruchy.Zakupy.Dao.Context.Entities.DefinicjaZamowienia
                {
                    Nazwa = definicja.Nazwa,
                    DataKoncaZamawiania = definicja.DataKoncaZamawiania
                };

                zakupyContext.DefinicjeZamowienia.Add(nowa);
                zakupyContext.SaveChanges();

                return nowa.ID;
            }
        }

        public IEnumerable<IDefinicjaZamowienia> Szukaj()
        {
            return
                zakupyContext
                    .DefinicjeZamowienia
                        .Select(o => new DefinicjaZamowienia(o));
        }

        private class DefinicjaZamowienia : IDefinicjaZamowienia
        {
            public DefinicjaZamowienia(Context.Entities.DefinicjaZamowienia entity)
            {
                ID = entity.ID;
                Nazwa = entity.Nazwa;
                DataKoncaZamawiania = entity.DataKoncaZamawiania;
            }

            public int ID { get; private set; }

            public string Nazwa { get; private set; }

            public DateTime DataKoncaZamawiania { get; private set; }
        }
    }
}
