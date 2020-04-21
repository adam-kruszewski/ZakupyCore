using System;
using Kruchy.Zamowienia.Dao;
using Kruchy.Zamowienia.Model;

namespace Kruchy.Zamowienia.Services.Impl
{
    class DefinicjeZamowienService : IDefinicjeZamowienService
    {
        private readonly IDefinicjaZamowieniaDao definicjaZamowieniaDao;

        public DefinicjeZamowienService(
            IDefinicjaZamowieniaDao definicjaZamowieniaDao)
        {
            this.definicjaZamowieniaDao = definicjaZamowieniaDao;
        }

        public int? Wstaw(IDefinicjaZamowienia definicja)
        {
            return definicjaZamowieniaDao.Wstaw(definicja);
        }

        private class DefinicjaZamowienia : IDefinicjaZamowienia
        {
            public int ID { get; set; }

            public string Nazwa { get; set; }

            public DateTime DataKoncaZamawiania { get; set; }

            public DefinicjaZamowienia(IDefinicjaZamowienia definicja)
            {
                ID = definicja.ID;
                Nazwa = definicja.Nazwa;
                DataKoncaZamawiania = definicja.DataKoncaZamawiania;
            }
        }
    }
}
