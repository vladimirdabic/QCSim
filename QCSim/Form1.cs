using MathNet.Numerics;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            circuitControl1.circuitWindow.CircuitUpdated += CircuitWindow_CircuitUpdated;
        }

        private void CircuitWindow_CircuitUpdated(object sender, EventArgs e)
        {
            // Add a checkbox for this perhaps
            // CalculateProbabilities();
        }

        private void newCircuit_Click(object sender, EventArgs e)
        {
            string qbitCount = "2";
            if(InputBox("New Circuit", "Enter number of QBits", ref qbitCount) == DialogResult.OK)
            {
                int.TryParse(qbitCount, out int qbitCountNum);
                
                if(qbitCountNum < 1)
                {
                    MessageBox.Show("A circuit must have at least 1 QBit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                circuitControl1.circuitWindow.NewCircuit(qbitCountNum);
                initialState.Text = new string('0', qbitCountNum);
                CalculateProbabilities();
            }
        }

        // Taken from some website, thanks
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new System.Windows.Forms.Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void calculateCircuit_Click(object sender, EventArgs e)
        {
            CalculateProbabilities();
        }

        private void CalculateProbabilities()
        {
            int qbitCount = circuitControl1.circuitWindow.QBitCount;
            if (qbitCount < 1) return;

            int bitIdx = 0;
            int initialVal = 0;
            for(int i = initialState.Text.Length - 1; i >= 0; --i)
            {
                char c = initialState.Text[i];

                if (c == '1')
                    initialVal |= 1 << bitIdx++;
                else if(c == '0')
                    bitIdx++;
            }


            State state = new State(qbitCount, initialVal);
            state.ApplyOperations(circuitControl1.circuitWindow.Operations.ToArray());

            probabilityChart.Series["Probability"].Points.Clear();

            List<string> finalStates = new List<string>();

            for (int i = 0; i < state.Vec.Count; i++)
            {
                double probability = Math.Round(Math.Pow(Complex32.Abs(state.Vec[i]), 2) * 100, 2);

                string stateLabel = "|";
                int mask = state.Vec.Count - 1;
                for (int j = qbitCount - 1; j >= 0; --j)
                {
                    stateLabel += (i & mask) >> j;
                    mask >>= 1;
                }
                stateLabel += "⟩";

                var idx = probabilityChart.Series["Probability"].Points.AddXY(stateLabel, probability);
                var point = probabilityChart.Series["Probability"].Points[idx];

                if (probability < 100)
                    point.Label = $"{probability}%";

                double realPart = Math.Round(state.Vec[i].Real, 2);
                double imPart = Math.Round(state.Vec[i].Imaginary, 2);
                string amplitude = string.Empty;

                if(realPart != 0)
                    amplitude += realPart;

                if(imPart != 0)
                {
                    if (realPart != 0) amplitude += " + ";
                    amplitude += $"{imPart}i";
                    if (realPart != 0) amplitude = $"({amplitude})";
                }

                if(amplitude == "1") finalStates.Add(stateLabel);
                else if(amplitude != string.Empty) finalStates.Add($"{amplitude}{stateLabel}");
            }

            probabilityChart.Titles["probState"].Text = $"|ψ⟩ = |{initialState}⟩\n|ψ'⟩ = {string.Join(" + ", finalStates)}\n\nProbability per state\n";
        }
    }
}
