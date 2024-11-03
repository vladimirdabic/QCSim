using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QCSim
{
    public partial class CircuitControl : UserControl
    {
        public CircuitControl()
        {
            InitializeComponent();

            circuitWindow.Paint += CircuitWindow_Paint;
        }

        private void CircuitWindow_Paint(object sender, PaintEventArgs e)
        {
            int vSize = circuitWindow.QBitCount * circuitWindow._tileSize + 16;
            if (vSize > circuitWindow.Height)
            {
                vScrollBar1.Enabled = true;
                vScrollBar1.Minimum = 0;
                vScrollBar1.Maximum = vSize - circuitWindow.Height;
            }
            else
            {
                vScrollBar1.Enabled = false;
            }

            int hSize = circuitWindow.Operations.Count * circuitWindow._tileSize + 16;
            if (hSize > circuitWindow.Width)
            {
                hScrollBar1.Enabled = true;
                hScrollBar1.Minimum = 0;
                hScrollBar1.Maximum = hSize - circuitWindow.Width;
            }
            else
            {
                hScrollBar1.Enabled = false;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            circuitWindow.CameraY = vScrollBar1.Value;
            circuitWindow.Invalidate();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            circuitWindow.CameraX = hScrollBar1.Value;
            circuitWindow.Invalidate();
        }
    }
}
