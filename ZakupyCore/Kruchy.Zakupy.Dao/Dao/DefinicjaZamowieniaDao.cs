using Kruchy.Model.DataTypes.Database;
using Kruchy.Zakupy.Dao.Context;
using Kruchy.Zakupy.Dao.Context.Entities;
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
                var nowa = new DefinicjaZamowienia
                {
                    Nazwa = definicja.Nazwa,
                    DataKoncaZamawiania = definicja.DataKoncaZamawiania
                };

                zakupyContext.DefinicjeZamowienia.Add(nowa);
                zakupyContext.SaveChanges();

                return nowa.ID;
            }
        }
    }
}
