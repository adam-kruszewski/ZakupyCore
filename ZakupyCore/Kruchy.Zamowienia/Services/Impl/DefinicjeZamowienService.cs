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
        private readonly IWczytywaniePlikuZamowieniaService wczytywaniePlikuZamowieniaService;

        public DefinicjeZamowienService(
            IDefinicjaZamowieniaDao definicjaZamowieniaDao,
            IWalidacjaDefinicjiZamowienia walidacjaDefinicji,
            IWczytywaniePlikuZamowieniaService wczytywaniePlikuZamowieniaService)
        {
            this.definicjaZamowieniaDao = definicjaZamowieniaDao;
            this.walidacjaDefinicji = walidacjaDefinicji;
            this.wczytywaniePlikuZamowieniaService = wczytywaniePlikuZamowieniaService;
        }

        public int? Wstaw(WstawienieDefinicjiZamowieniaRequest request)
        {
            var definicja = new DefinicjaZamowienia
            {
                Nazwa = request.Nazwa,
                DataKoncaZamawiania = request.DataKoncaZamawiania
            };

            if (WalidacjaHelper.Waliduj(o => walidacjaDefinicji.Waliduj(definicja, o)))
                return null;

            var definicjaZamowienia =
                wczytywaniePlikuZamowieniaService
                    .Wczytaj(request.ZawartoscPliku);

            return definicjaZamowieniaDao.Wstaw(definicja);
        }

        private class DefinicjaZamowienia : IDefinicjaZamowienia
        {
            public int ID { get; set; }

            public string Nazwa { get; set; }

            public DateTime DataKoncaZamawiania { get; set; }

            public DefinicjaZamowienia()
            {

            }

            public DefinicjaZamowienia(IDefinicjaZamowienia definicja)
            {
                ID = definicja.ID;
                Nazwa = definicja.Nazwa;
                DataKoncaZamawiania = definicja.DataKoncaZamawiania;
            }
        }
    }
}
