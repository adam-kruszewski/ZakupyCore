using System;

namespace Kruchy.Model.DataTypes.Walidacja
{
    public static class WalidacjaHelper
    {
        public static bool Waliduj(Func<IWalidacjaListener, bool> funkcjaSprawdzenia)
        {
            return funkcjaSprawdzenia(new WalidacjaListener());
        }

        private class WalidacjaListener : IWalidacjaListener
        {
            public void Blad(string komunikat, string wlasciwosc)
            {
            }

            public void Ostrzezenie(string komunikat, string wlasciwosc)
            {
            }
        }
    }
}