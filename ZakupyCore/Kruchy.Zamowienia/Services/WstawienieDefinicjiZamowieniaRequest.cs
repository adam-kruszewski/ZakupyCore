using System;

namespace Kruchy.Zamowienia.Services
{
    public class WstawienieDefinicjiZamowieniaRequest
    {
        public string Nazwa { get; set; }

        public DateTime DataKoncaZamawiania { get; set; }

        public byte[] ZawartoscPliku { get; set; }
    }
}
