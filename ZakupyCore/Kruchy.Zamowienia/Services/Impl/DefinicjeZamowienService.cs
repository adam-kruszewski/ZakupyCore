using System;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zamowienia.Dao;
using Kruchy.Zamowienia.Model;
using Kruchy.Zamowienia.Walidacja;

namespace Kruchy.Zamowienia.Services.Impl
{
    class DefinicjeZamowienService : IDefinicjeZamowienService
    {
        private readonly IDefinicjaZamowieniaDao definicjaZamowieniaDao;
        private readonly IWalidacjaDefinicjiZamowienia walidacjaDefinicji;

        public DefinicjeZamowienService(
            IDefinicjaZamowieniaDao definicjaZamowieniaDao,
            IWalidacjaDefinicjiZamowienia walidacjaDefinicji)
        {
            this.definicjaZamowieniaDao = definicjaZamowieniaDao;
            this.walidacjaDefinicji = walidacjaDefinicji;
        }

        public int? Wstaw(IDefinicjaZamowienia definicja)
        {
            if (WalidacjaHelper.Waliduj(o => walidacjaDefinicji.Waliduj(definicja, o)))
                return null;

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
