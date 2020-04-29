namespace Kruchy.Zakupy.Dao.Context.Entities
{
    public class Produkt
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public decimal Cena { get; set; }

        public int GrupaProduktowId { get; set; }

        public int NumerWierszaWExcelu { get; set; }
    }
}