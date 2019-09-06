using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ampel
{
    public partial class AmpelControl : UserControl
    {
        public AmpelControl()
        {
            InitializeComponent();
        }

        private AmpelBildEnum _ampelBild;

        public AmpelBildEnum AmpelBild
        {
            get { return _ampelBild; }
            set
            {
                _ampelBild = value;
                panel1.Invalidate();
                panel2.Invalidate();
                panel3.Invalidate();
            }
        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {
            int lampe = 0;
            Brush brush;
            if (sender == panel1)
            {
                brush = Brushes.Crimson;
                lampe = 1;
            }
            else if (sender == panel2)
            {
                brush = Brushes.Yellow;
                lampe = 1 << 1;
            }
            else if (sender == panel3)
            {
                brush = Brushes.DarkGreen;
                lampe = 1 << 2;
            }
            else
            {
                return;
            }
            if ((lampe & (int)AmpelBild) > 0)
            {
                e.Graphics.FillEllipse(brush, new Rectangle(new Point(0, 0), (sender as Control).Size));
            }
            else
            {
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle(new Point(0, 0), (sender as Control).Size));
            }

        }
    }
}
