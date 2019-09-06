using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ampel
{
    public enum AmpelBildEnum
    {
        // rot ist bit 1 ... gelb ist bit 2 ... grün ist bit 3

        Rot = 1,
        RotGelb = 1 << 1 | 1 << 0,
        Grün = 1 << 2,
        Gelb = 1 << 1,
        Aus = 0,
    }
}
