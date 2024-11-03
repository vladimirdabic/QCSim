using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.QC
{
    public class Layer : IOperation
    {
        public static Matrix<Complex32> Identity = Matrix<Complex32>.Build.DiagonalIdentity(2, 2);
        public Gate[] Gates { get => _gates; }
        public bool IsEmpty
        {
            get
            {
                foreach (var gate in _gates)
                    if (gate != null) return false;
                return true;
            }
        }

        public int QBitCount { get; private set; }
        private readonly Gate[] _gates;

        public Layer(int qbitCount)
        {
            QBitCount = qbitCount;
            _gates = new Gate[qbitCount];
        }
            
        public void SetGate(int idx, Gate gate)
        {
            //gate.Owner = this;
            _gates[idx] = gate;
        }

        public Matrix<Complex32> M
        {
            get
            {
                Matrix<Complex32> op = _gates[0] is null ? Identity : _gates[0].M;
                Gate cur;

                for (int i = 1; i < _gates.Length; ++i)
                {
                    cur = _gates[i];

                    if (cur == null)
                        op = TensorProduct(op, Identity);
                    else
                        op = TensorProduct(op, cur.M);
                }
                
                return op;
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
