using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.QC
{
    public abstract class Gate : IOperation
    {
        public abstract Matrix<Complex32> M { get; }
        public abstract void Draw(int topX, int topY, Graphics g);

        public Gate() { }

        public class X : Gate
        {
            private static readonly Matrix<Complex32> _m = Matrix<Complex32>.Build.DenseOfArray(new Complex32[,] {
                        {0, 1},
                        {1, 0}
                    });

            public override Matrix<Complex32> M => _m;

            public override void Draw(int topX, int topY, Graphics g)
            {
                g.FillRectangle(new SolidBrush(Color.Blue), topX, topY, 32, 32);
                g.DrawRectangle(new Pen(Color.Black), topX, topY, 32, 32);

                using (Font myFont = new Font("Cambria", 14, FontStyle.Bold))
                {
                    g.DrawString("X", myFont, Brushes.LightBlue, new Point(topX + 8, topY + 6));
                }
            }
        }

        public class Z : Gate
        {
            private static readonly Matrix<Complex32> _m = Matrix<Complex32>.Build.DenseOfArray(new Complex32[,] {
                        {1, 0},
                        {0, -1}
                    });

            public override Matrix<Complex32> M => _m;

            public override void Draw(int topX, int topY, Graphics g)
            {
                g.FillRectangle(new SolidBrush(Color.DarkGray), topX, topY, 32, 32);
                g.DrawRectangle(new Pen(Color.Black), topX, topY, 32, 32);

                using (Font myFont = new Font("Cambria", 14, FontStyle.Bold))
                {
                    g.DrawString("Z", myFont, Brushes.LightGray, new Point(topX + 8, topY + 6));
                }
            }
        }

        public class Y : Gate
        {
            private static readonly Matrix<Complex32> _m = Matrix<Complex32>.Build.DenseOfArray(new Complex32[,] {
                        {0, new Complex32(0, -1)},
                        {new Complex32(0, 1), 0}
                    });

            public override Matrix<Complex32> M => _m;

            public override void Draw(int topX, int topY, Graphics g)
            {
                g.FillRectangle(new SolidBrush(Color.DarkGray), topX, topY, 32, 32);
                g.DrawRectangle(new Pen(Color.Black), topX, topY, 32, 32);

                using (Font myFont = new Font("Cambria", 14, FontStyle.Bold))
                {
                    g.DrawString("Y", myFont, Brushes.LightGray, new Point(topX + 8, topY + 6));
                }
            }
        }

        public class Hadamard : Gate
        {
            private static readonly Matrix<Complex32> _m = Matrix<Complex32>.Build.DenseOfArray(new Complex32[,] {
                        {new Complex32((float)(1/Math.Sqrt(2)), 0), new Complex32((float)(1/Math.Sqrt(2)), 0)},
                        {new Complex32((float)(1/Math.Sqrt(2)), 0), new Complex32((float)(-1/Math.Sqrt(2)), 0)}
                    });

            public override Matrix<Complex32> M => _m;

            public override void Draw(int topX, int topY, Graphics g)
            {
                g.FillRectangle(new SolidBrush(Color.IndianRed), topX, topY, 32, 32);
                g.DrawRectangle(new Pen(Color.Black), topX, topY, 32, 32);

                using (Font myFont = new Font("Cambria", 14, FontStyle.Bold))
                {
                    g.DrawString("H", myFont, Brushes.DarkRed, new Point(topX + 6, topY + 4));
                }
            }
        }
    }
}
