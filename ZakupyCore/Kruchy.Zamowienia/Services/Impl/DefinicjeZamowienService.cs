using System;
using System.Collections.Generic;
using System.Linq;
using Kruchy.Model.DataTypes.Database;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zamowienia.Dao;
using Kruchy.Zamowienia.Model;
using Kruchy.Zamowienia.Model.PlikZamowienia;
using Kruchy.Zamowienia.Walidacja;

namespace Kruchy.Zamowienia.Services.Impl
{
    class DefinicjeZamowienService : IDefinicjeZamowienService
    {
        private readonly IDefinicjaZamowieniaDao definicjaZamowieniaDao;
        private readonly IWalidacjaDefinicjiZamowienia walidacjaDefinicji;
        private readonly IWczytywaniePlikuZamowieniaService wczytywaniePlikuZamowieniaService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGrupaProduktowDao grupaProduktowDao;

        public DefinicjeZamowienService(
            IDefinicjaZamowieniaDao definicjaZamowieniaDao,
            IWalidacjaDefinicjiZamowienia walidacjaDefinicji,
            IWczytywaniePlikuZamowieniaService wczytywaniePlikuZamowieniaService,
            IUnitOfWork unitOfWork,
            IGrupaProduktowDao grupaProduktowDao)
        {
            this.definicjaZamowieniaDao = definicjaZamowieniaDao;
            this.walidacjaDefinicji = walidacjaDefinicji;
            this.wczytywaniePlikuZamowieniaService = wczytywaniePlikuZamowieniaService;
            this.unitOfWork = unitOfWork;
            this.grupaProduktowDao = grupaProduktowDao;
        }

        public int? Wstaw(WstawienieDefinicjiZamowieniaRequest request)
        {
            int? definicjaID;
            using (var usingUnit = new UsingUnitOfWork(unitOfWork))
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

                definicjaID = definicjaZamowieniaDao.Wstaw(definicja);

                if (!definicjaID.HasValue)
                {
                    usingUnit.Cancel();
                    return null;
                }

                if (!ZapiszGrupyProduktow(definicjaZamowienia, definicjaID.Value))
                {
                    usingUnit.Cancel();
                    return null;
                }
            }

            return definicjaID;
        }

        private bool ZapiszGrupyProduktow(
            Zamowienie definicjaZamowienia,
            int definicjaID)
        {
            return
                definicjaZamowienia
                    .GrupyProduktow.All(
                        o => ZapiszGrupeProduktow(o, definicjaID));
        }

        private bool ZapiszGrupeProduktow(
            Kruchy.Zamowienia.Model.PlikZamowienia.GrupaProduktow grupa,
            int definicjaID)
        {
            var grupaDoWstawienia = new GrupaProduktow()
            {
                DefinicjaZamowieniaId = definicjaID,
                Limit = grupa.MinimalneIlosci,
                Nazwa = grupa.Nazwa
            };
            grupaDoWstawienia.DodajProdukty(PrzygotujProdukty(grupa.Pozycje));

            var grupaID = grupaProduktowDao.Wstaw(grupaDoWstawienia);

            return grupaID.HasValue;
        }

        private IEnumerable<IProdukt> PrzygotujProdukty(
            IList<Model.PlikZamowienia.Produkt> pozycje)
        {
            return pozycje.Select(o => DajProdukt(o));
        }

        private IProdukt DajProdukt(Model.PlikZamowienia.Produkt o)
        {
            return new Produkt
            {
                Nazwa = o.Nazwa,
                NumerWierszaWExcelu = o.NumerPozycjiWExcelu,
                Cena = o.CenaDecimal
            };
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

        private class GrupaProduktow : IGrupaProduktow
        {
            public GrupaProduktow()
            {
                _produkty = new List<IProdukt>();
            }

            public string Nazwa { get; set; }
            public int? Limit { get; set; }
            public int DefinicjaZamowieniaId { get; set; }
            
            private List<IProdukt> _produkty;

            public IEnumerable<IProdukt> Produkty { get { return _produkty; } }

            public void DodajProdukt(IProdukt produkt)
            {
                _produkty.Add(produkt);
            }

            public void DodajProdukty(IEnumerable<IProdukt> produkty)
            {
                _produkty.AddRange(produkty);
            }
        }

        private class Produkt : IProdukt
        {
            public string Nazwa { get; set; }
            public decimal Cena { get; set; }
            public int NumerWierszaWExcelu { get; set; }
        }
    }
}
