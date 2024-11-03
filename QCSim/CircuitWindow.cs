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
    public partial class CircuitWindow : PictureBox
    {
        public int QBitCount { get; private set; }

        public int CameraX = 0;
        public int CameraY = 0;
        public readonly List<IOperation> Operations;
        public event EventHandler CircuitUpdated;

        private bool _inWindow = false;
        private readonly SolidBrush WHITE_BRUSH = new SolidBrush(Color.White);
        private readonly SolidBrush EMPTY_GATE_BRUSH = new SolidBrush(Color.LightGray);
        private readonly SolidBrush CTRL_BRUSH = new SolidBrush(Color.Black);
        private readonly Pen CTRL_PEN = new Pen(Color.Black);
        private readonly Pen LINE_PEN = new Pen(Color.LightGray, 2);
        private readonly Pen SELECT_PEN = new Pen(Color.DarkGray);

        internal int _tileSize = 64;
        private int _mouseX = 0;
        private int _mouseY = 0;

        private GateForm _gateForm = new GateForm();

        public CircuitWindow()
        {
            InitializeComponent();

            Paint += CircuitWindow_Paint;
            MouseEnter += CircuitWindow_MouseEnter;
            MouseLeave += CircuitWindow_MouseLeave;
            MouseMove += CircuitWindow_MouseMove;
            MouseDoubleClick += CircuitWindow_MouseDoubleClick;
            MouseClick += CircuitWindow_MouseClick;

            PreviewKeyDown += CircuitWindow_PreviewKeyDown;

            Operations = new List<IOperation>();
            QBitCount = -1;
        }

        private void CircuitWindow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    RemoveCurrentLayer();
                    break;

                case Keys.Insert:
                    InsertToLeft();
                    break;
            }
        }

        private void CircuitWindow_MouseClick(object sender, MouseEventArgs e)
        {
            if (QBitCount <= 0) return;

            int opIdx = _mouseX;
            int subOpIdx = _mouseY;

            if (e.Button == MouseButtons.Right)
            {
                if (opIdx >= Operations.Count) return;
                IOperation op = Operations[opIdx];

                if(op is Layer layer)
                {
                    if (layer.Gates[subOpIdx] == null) return;
                    layer.Gates[subOpIdx] = null;
                }
                else if(op is ControlledLayer cLayer)
                {
                    if (subOpIdx != cLayer.TargetQBit) return;
                    Operations[opIdx] = new Layer(QBitCount);
                }

                Invalidate();
                CircuitUpdated(this, null);
            }
        }

        private void CircuitWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (QBitCount <= 0) return;

            int opIdx = _mouseX;
            int subOpIdx = _mouseY;
            IOperation op;

            if (opIdx > Operations.Count) return;
            else if (opIdx < Operations.Count)
            {
                op = Operations[opIdx];
                if (op is Layer layer && layer.Gates[subOpIdx] != null) return;
                else if (op is ControlledLayer) return;
            }

            _gateForm._qbitCount = QBitCount;
            _gateForm._targetQBit = subOpIdx;
            _gateForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult res = _gateForm.ShowDialog();
            if (res != DialogResult.OK) return;

            if(opIdx < Operations.Count)
            {
                op = Operations[opIdx];

                if (op is Layer layer)
                {
                    if (_gateForm.ControlQBitsResult.Count == 0 || !layer.IsEmpty)
                        layer.Gates[subOpIdx] = _gateForm.DialogGateResult;
                    else
                        Operations[opIdx] = new ControlledLayer(QBitCount, _gateForm.DialogGateResult, _gateForm.ControlQBitsResult.ToArray(), subOpIdx);

                    Invalidate();
                    CircuitUpdated(this, null);
                }
            }
            else // inserting
            {
                if(_gateForm.ControlQBitsResult.Count == 0)
                {
                    Layer l = AddLayer();
                    l.Gates[subOpIdx] = _gateForm.DialogGateResult;
                }
                else
                {
                    AddControlledLayer(new ControlledLayer(QBitCount, _gateForm.DialogGateResult, _gateForm.ControlQBitsResult.ToArray(), subOpIdx));
                }
                Invalidate();
                CircuitUpdated(this, null);
            }
        }

        private void CircuitWindow_MouseMove(object sender, MouseEventArgs e)
        {
            _mouseX = ToWorldX(e.X) / _tileSize;
            _mouseY = ToWorldY(e.Y) / _tileSize;
            
            Invalidate();
        }

        private void CircuitWindow_MouseLeave(object sender, EventArgs e)
        {
            _inWindow = false;
            Invalidate();
        }

        private void CircuitWindow_MouseEnter(object sender, EventArgs e)
        {
            Focus();
            _inWindow = true;
        }

        private void CircuitWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(WHITE_BRUSH, 0, 0, Width, Height);

            for (int j = 0; j < QBitCount; ++j)
            {
                e.Graphics.DrawLine(LINE_PEN, 0, ToScreenY(j * _tileSize + (_tileSize / 2)), Width, ToScreenY(j * _tileSize + (_tileSize / 2)));
            }

            for (int i = 0; i < Operations.Count; ++i)
            {
                var op = Operations[i];

                if(op is Layer layer)
                {
                    for(int j = 0; j < layer.QBitCount; ++j)
                    {
                        // Draw each gate on line
                        if (layer.Gates[j] == null) continue;

                        layer.Gates[j].Draw(ToScreenX(i * _tileSize + (_tileSize / 4)), ToScreenY(j * _tileSize + (_tileSize / 4)), e.Graphics);
                    }
                } 
                else if(op is ControlledLayer cLayer)
                {
                    // Draw ctrl lines
                    for(int j = 0; j < cLayer.ControlQBits.Length; j++)
                    {
                        int ctrlQbit = cLayer.ControlQBits[j];
                        e.Graphics.FillRectangle(CTRL_BRUSH, ToScreenX(i * _tileSize + 24), ToScreenY(ctrlQbit * _tileSize + 24), _tileSize / 4, _tileSize/4);

                        e.Graphics.DrawLine(CTRL_PEN, ToScreenX(i * _tileSize + _tileSize / 2), ToScreenY(ctrlQbit * _tileSize + _tileSize / 2), ToScreenX(i * _tileSize + _tileSize / 2), ToScreenY(cLayer.TargetQBit * _tileSize + _tileSize / 2));
                    }

                    cLayer.GateRef.Draw(ToScreenX(i * _tileSize + (_tileSize / 4)), ToScreenY(cLayer.TargetQBit * _tileSize + (_tileSize / 4)), e.Graphics);
                }
            }

            if(_mouseX < Operations.Count + 1 && _mouseY < QBitCount)
                e.Graphics.DrawRectangle(SELECT_PEN, ToScreenX(_mouseX * _tileSize + _tileSize / 4), ToScreenY(_mouseY * _tileSize + _tileSize / 4), 32, 32);
        }

        private int ToScreenX(int worldX)
        {
            return worldX - CameraX;
        }

        private int ToScreenY(int worldY)
        {
            return worldY - CameraY;
        }

        private int ToWorldX(int screenX)
        {
            return screenX + CameraX;
        }

        private int ToWorldY(int screenY)
        {
            return screenY + CameraY;
        }

        public void NewCircuit(int qbitCount)
        {
            QBitCount = qbitCount;
            Operations.Clear();
            CameraX = 0;
            CameraY = 0;
            Invalidate();
        }

        public Layer AddLayer()
        {
            Layer l = new Layer(QBitCount);
            Operations.Add(l);
            Invalidate();
            return l;
        }

        public ControlledLayer AddControlledLayer(ControlledLayer l)
        {
            Operations.Add(l);
            Invalidate();
            return l;
        }

        public void RemoveCurrentLayer()
        {
            if (QBitCount <= 0) return;

            int opIdx = _mouseX;

            if (opIdx >= Operations.Count) return;
            Operations.RemoveAt(opIdx);
            Invalidate();
            CircuitUpdated(this, null);
        }

        public void InsertToLeft()
        {
            if (QBitCount <= 0) return;

            int opIdx = _mouseX;
            if (opIdx >= Operations.Count) return;

            Layer l = new Layer(QBitCount);
            Operations.Insert(opIdx, l);
            Invalidate();
        }
    }
}
