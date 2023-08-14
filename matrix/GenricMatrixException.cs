using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    class GenricMatrixException : Exception
    {
        public GenricMatrixException(string msg) : base(msg)
        {

        }
    }
}
