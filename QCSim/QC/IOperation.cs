using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;


namespace VD.QC
{
    public interface IOperation
    {
        Matrix<Complex32> M { get; }
    }
}
