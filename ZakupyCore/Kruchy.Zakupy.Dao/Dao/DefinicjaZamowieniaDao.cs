using Kruchy.Zakupy.Dao.Context;
using Kruchy.Zakupy.Dao.Context.Entities;
using Kruchy.Zamowienia.Dao;
using Kruchy.Zamowienia.Model;

namespace Kruchy.Zakupy.Dao.Dao
{
    class DefinicjaZamowieniaDao : IDefinicjaZamowieniaDao
    {
        private readonly ZakupyContext zakupyContext;

        public DefinicjaZamowieniaDao(
            ZakupyContext zakupyContext)
        {
            this.zakupyContext = zakupyContext;
        }

        public int Wstaw(IDefinicjaZamowienia definicja)
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
