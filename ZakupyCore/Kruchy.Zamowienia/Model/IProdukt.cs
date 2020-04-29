namespace Kruchy.Zamowienia.Model
{
    public interface IProdukt
    {
        public string Nazwa { get; set; }

        public decimal Cena { get; set; }

        public int NumerWierszaWExcelu { get; set; }
    }
}