using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ampel.FußgängerAmpel
{
    public class FußgängerAmpelZustand : IAmpelZustand<FußgängerAmpelEventsEnum, FußgängerAmpelnEnum>
    {
        public TimeSpan Wartezeit { get; set; }

        public Func<IAmpelZustand<FußgängerAmpelEventsEnum, FußgängerAmpelnEnum>> KnopfGedrückt { get; set; }
        public Func<IAmpelZustand<FußgängerAmpelEventsEnum, FußgängerAmpelnEnum>> WartezeitAbgelaufen { get; set; }
        public AmpelBildEnum Fußgänger { get; set; }
        public AmpelBildEnum Autos { get; set; }

        public IAmpelZustand<FußgängerAmpelEventsEnum, FußgängerAmpelnEnum> EventEingetreten(FußgängerAmpelEventsEnum Ereignis)
        {
            switch (Ereignis)
            {
                case FußgängerAmpelEventsEnum.WartezeitAbgelaufen:
                    return WartezeitAbgelaufen() ?? this;
                case FußgängerAmpelEventsEnum.KnopfGedrückt:
                    return KnopfGedrückt() ?? this;
                default:
                    throw new NotImplementedException();
            }
        }

        public AmpelBildEnum getAmpelBild(FußgängerAmpelnEnum welcheAmpel)
        {
            switch (welcheAmpel)
            {
                case FußgängerAmpelnEnum.Autos:
                    return Autos;
                case FußgängerAmpelnEnum.Fußgänger:
                    return Fußgänger;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
