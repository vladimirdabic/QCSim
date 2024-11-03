using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.QC
{
    public class ControlledLayer : IOperation
    {
        public static Matrix<Complex32> Identity = Matrix<Complex32>.Build.DiagonalIdentity(2, 2);
        public static Matrix<Complex32> P0 = Matrix<Complex32>.Build.DenseOfArray(new Complex32[2, 2]
        {
            { 1, 0 },
            { 0, 0 }
        });
        public static Matrix<Complex32> P1 = Matrix<Complex32>.Build.DenseOfArray(new Complex32[2, 2]
        {
            { 0, 0 },
            { 0, 1 }
        });

        public int QBitCount { get; private set; }
        public int[] ControlQBits { get; private set; }
        public int TargetQBit { get; private set; }
        public Gate GateRef { get; private set;  }

        public ControlledLayer(int qbitCount, Gate gate, int[] controlQbits, int targetQbit)
        {
            QBitCount = qbitCount;
            ControlQBits = controlQbits;
            GateRef = gate;
            TargetQBit = targetQbit;
        }

        public Matrix<Complex32> M
        {
            get
            {
                int dim = (int)Math.Pow(2, QBitCount);
                Matrix<Complex32> op = Matrix<Complex32>.Build.Dense(dim, dim, 0);
                Matrix<Complex32> cur;
                List<int> seen = new List<int>();

                for(int i = 0; i < ControlQBits.Length; ++i)
                {
                    cur = null;

                    for (int j = 0; j < QBitCount; ++j)
                    {
                        Matrix<Complex32> projOp = seen.Contains(j) ? P1 : P0;

                        if (ControlQBits.Contains(j))
                            cur = TensorProduct(cur, projOp);
                        else
                            cur = TensorProduct(cur, Identity);
                    }

                    seen.Add(ControlQBits[i]);
                    op += cur;
                }

                cur = null;
                for (int j = 0; j < QBitCount; ++j)
                {
                    if (ControlQBits.Contains(j))
                        cur = TensorProduct(cur, P1);
                    else if (j == TargetQBit)
                        cur = TensorProduct(cur, GateRef.M);
                    else
                        cur = TensorProduct(cur, Identity);
                }
                // op += cur;

                return op + cur;
            }
        }


        public static Matrix<Complex32> TensorProduct(Matrix<Complex32> A, Matrix<Complex32> B)
        {
            if (A == null) return B;
            if (B == null) return A;

            int m = A.RowCount;
            int n = A.ColumnCount;
            int p = B.RowCount;
            int q = B.ColumnCount;

            var result = Matrix<Complex32>.Build.Dense(m * p, n * q);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.SetSubMatrix(i * p, j * q, A[i, j] * B);
                }
            }
            return result;
        }
    }
}
