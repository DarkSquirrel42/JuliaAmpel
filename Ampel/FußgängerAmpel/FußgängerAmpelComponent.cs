using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ampel.FußgängerAmpel
{
    public partial class FußgängerAmpelComponent : Component
    {
        public FußgängerAmpelComponent()
        {
            InitializeComponent();
            init();
        }

        public FußgängerAmpelComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            init();
        }
        private Dictionary<ZuständeEnum, FußgängerAmpelZustand> zustände = new Dictionary<ZuständeEnum, FußgängerAmpelZustand>();
        private void init()
        {
            Zustand = zustände[ZuständeEnum.AutosGrün] = new FußgängerAmpelZustand()
            {
                Autos = AmpelBildEnum.Grün,
                Fußgänger = AmpelBildEnum.Rot,
                Wartezeit = TimeSpan.FromDays(1),
                WartezeitAbgelaufen = () => null,
                KnopfGedrückt= ()=>zustände[ZuständeEnum.WartezeitFürFußgänger]
            };
            zustände[ZuständeEnum.WartezeitFürFußgänger] = new FußgängerAmpelZustand()
            {
                Autos = AmpelBildEnum.Grün,
                Fußgänger = AmpelBildEnum.Rot,
                Wartezeit = TimeSpan.FromSeconds(10),
                WartezeitAbgelaufen = () => zustände[ZuständeEnum.AutosGelb],
                KnopfGedrückt = () => null
            };
            zustände[ZuständeEnum.AutosGelb] = new FußgängerAmpelZustand()
            {
                Autos = AmpelBildEnum.Gelb,
                Fußgänger = AmpelBildEnum.Rot,
                Wartezeit = TimeSpan.FromSeconds(4),
                WartezeitAbgelaufen = () => zustände[ZuständeEnum.AutosRotFußgängerRot],
                KnopfGedrückt = () => null
            };
            zustände[ZuständeEnum.AutosRotFußgängerRot] = new FußgängerAmpelZustand()
            {
                Autos = AmpelBildEnum.Rot,
                Fußgänger = AmpelBildEnum.Rot,
                Wartezeit = TimeSpan.FromSeconds(1),
                WartezeitAbgelaufen = () => zustände[ZuständeEnum.AutosRotFußgängerGrün],
                KnopfGedrückt = () => null
            };
            zustände[ZuständeEnum.AutosRotFußgängerGrün] = new FußgängerAmpelZustand()
            {
                Autos = AmpelBildEnum.Rot,
                Fußgänger = AmpelBildEnum.Grün,
                Wartezeit = TimeSpan.FromSeconds(10),
                WartezeitAbgelaufen = () => zustände[ZuständeEnum.AutosRotFußgängerRot2],
                KnopfGedrückt = () => null
            };
            zustände[ZuständeEnum.AutosRotFußgängerRot2] = new FußgängerAmpelZustand()
            {
                Autos = AmpelBildEnum.Rot,
                Fußgänger = AmpelBildEnum.Rot,
                Wartezeit = TimeSpan.FromSeconds(1),
                WartezeitAbgelaufen = () => zustände[ZuständeEnum.AutosRotGelb],
                KnopfGedrückt = () => null
            };
            zustände[ZuständeEnum.AutosRotGelb] = new FußgängerAmpelZustand()
            {
                Autos = AmpelBildEnum.RotGelb,
                Fußgänger = AmpelBildEnum.Rot,
                Wartezeit = TimeSpan.FromSeconds(1),
                WartezeitAbgelaufen = () => zustände[ZuständeEnum.AutosGrün],
                KnopfGedrückt = () => null
            };
        }

        private enum ZuständeEnum
        {
            AutosGrün,
            WartezeitFürFußgänger,
            AutosGelb,
            AutosRotFußgängerRot,
            AutosRotFußgängerGrün,
            AutosRotFußgängerRot2,
            AutosRotGelb
        }

        public AmpelControl FußgängerAmpel { get; set; }
        public AmpelControl AutoAmpel { get; set; }
        private Button _Knopf;

        public Button Knopf
        {
            get { return _Knopf; }
            set { _Knopf = value;
                _Knopf.Click += _Knopf_Click;
            }
        }

        private void _Knopf_Click(object sender, EventArgs e)
        {
            ZustandsÜbergang(FußgängerAmpelEventsEnum.KnopfGedrückt);
        }

        private IAmpelZustand<FußgängerAmpelEventsEnum, FußgängerAmpelnEnum> Zustand { get; set; }

        public void Start()
        {
            timer1.Start();
            übernehmeBild();
        }
        public void Stop()
        {
            timer1.Stop();
        }

        DateTime? zustandAktiviert;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!zustandAktiviert.HasValue || zustandAktiviert.Value + Zustand.Wartezeit < DateTime.Now)
            {
                ZustandsÜbergang(FußgängerAmpelEventsEnum.WartezeitAbgelaufen);
            }
        }

        private void ZustandsÜbergang(FußgängerAmpelEventsEnum ereignis)
        {
            var tmp = Zustand.EventEingetreten(ereignis);
            if (tmp != Zustand)
            {
                Zustand = tmp;
                zustandAktiviert = DateTime.Now;
                übernehmeBild();
            }
        }

        private void übernehmeBild()
        {
            AutoAmpel.AmpelBild = Zustand.getAmpelBild(FußgängerAmpelnEnum.Autos);
            FußgängerAmpel.AmpelBild = Zustand.getAmpelBild(FußgängerAmpelnEnum.Fußgänger);
        }
    }
}
