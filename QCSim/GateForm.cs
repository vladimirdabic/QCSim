using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VD.QC;

namespace QCSim
{
    public partial class GateForm : Form
    {
        public Gate DialogGateResult { get; private set; }
        public readonly List<int> ControlQBitsResult;

        internal int _qbitCount;
        internal int _targetQBit;

        public GateForm()
        {
            InitializeComponent();
            ControlQBitsResult = new List<int>();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (typeList.SelectedItems.Count != 1) return;
            ListViewItem item = typeList.SelectedItems[0];

            switch (item.ImageKey)
            {
                case "hadamard": DialogGateResult = new Gate.Hadamard(); break;
                case "x": DialogGateResult = new Gate.X(); break;
                case "y": DialogGateResult = new Gate.Y(); break;
                case "z": DialogGateResult = new Gate.Z(); break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeList.SelectedItems.Count != 1) return;
            ListViewItem item = typeList.SelectedItems[0];

            switch(item.ImageKey)
            {
                case "hadamard": descBox.Text = "Puts the qbit in an equal superposition"; break;
                case "x": descBox.Text = "Peforms a logical NOT operation on a qbit"; break;
                case "y": descBox.Text = "Peforms a bit and phase flip on a qbit"; break;
                case "z": descBox.Text = "Peforms a phase flip on a qbit (|1> basis state)"; break;
            }
        }

        private void GateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlQbitPanel.Controls.Clear();
        }

        private void qbitCheckChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            int ctrlQbitIdx = controlQbitPanel.Controls.IndexOf(cb);

            if (cb.Checked)
                ControlQBitsResult.Add(ctrlQbitIdx);
            else
                ControlQBitsResult.Remove(ctrlQbitIdx);
        }

        public new DialogResult ShowDialog()
        {
            ControlQBitsResult.Clear();

            for (int i = 0; i < _qbitCount; ++i)
            {
                CheckBox cb = new CheckBox()
                {
                    Text = $"QBit {i}",
                    Checked = false,
                    Enabled = i != _targetQBit,
                    Width = 75
                };

                cb.CheckedChanged += qbitCheckChanged;
                controlQbitPanel.Controls.Add(cb);
            }

            DialogResult res = base.ShowDialog();
            return res;
        }
    }
}
