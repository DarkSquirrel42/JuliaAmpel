using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ampel
{
    public interface IAmpelZustand<TEvent,TAmpeln> where TEvent:Enum where TAmpeln:Enum
    {
        IAmpelZustand<TEvent, TAmpeln> EventEingetreten(TEvent Ereignis);
        TimeSpan Wartezeit { get; }
        AmpelBildEnum getAmpelBild(TAmpeln welcheAmpel);
    }
}
