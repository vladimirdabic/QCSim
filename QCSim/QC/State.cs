using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.QC
{
    public class State
    {
        public Vector<Complex32> Vec { get; private set; }

        public State(int qbitCount, int initialValue)
        {
            Vec = Vector<Complex32>.Build.Dense((int)Math.Pow(2, qbitCount), 0);

            int bitMask = (1 << qbitCount) - 1;
            int value = initialValue & bitMask;

            Vec[value] = 1;
        }

        public State(int qbitCount) : this(qbitCount, 0)
        {

        }

        public void ApplyOperation(IOperation op)
        {
            Vec *= op.M;
        }

        public void ApplyOperations(params IOperation[] ops)
        {
            foreach(IOperation op in ops)            
                Vec *= op.M;
        }
    }
}
