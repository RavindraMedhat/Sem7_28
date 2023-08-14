using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
        input:

            Console.Write("ENTER NUMBER OF ROW :-");
            Int32 m1_Rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("ENTER NUMBER OF COL :-");
            Int32 m1_Cols = Convert.ToInt32(Console.ReadLine());

            GenricMatrix<int> m1 = new GenricMatrix<int>(m1_Rows, m1_Cols);
            m1.setMatrix();

            Console.WriteLine("m1 :- ");
            m1.getMatrix();


            Console.Write("ENTER NUMBER OF ROW :-");
            Int32 m2_Rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("ENTER NUMBER OF COL :-");
            Int32 m2_Cols = Convert.ToInt32(Console.ReadLine());

            GenricMatrix<int> m2 = new GenricMatrix<int>(m2_Rows, m2_Cols);
            m2.setMatrix();

            Console.WriteLine("m2 :- ");
            m2.getMatrix();


            try
            {
                if (m1.m.GetLength(0) != m2.m.GetLength(0) || m1.m.GetLength(1) != m2.m.GetLength(1))
                {
                    throw new GenricMatrixException("Matrix addition requires matrices of the same dimensions.");
                }

                GenricMatrix<int> add = new GenricMatrix<int>(m1.Rows, m1.Cols);
                add.Addition(m1.m, m2.m);

                Console.WriteLine("Addition :- ");
                add.getMatrix();

                GenricMatrix<int> sub = new GenricMatrix<int>(m1.Rows, m1.Cols);
                sub.Substraction(m1.m, m2.m);
                
                Console.WriteLine("Substraction :- ");
                sub.getMatrix();

            }
            catch (GenricMatrixException ex)
            {
                Console.WriteLine("matrix operation failed:" + ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("an unexpected error occured:" + ex.Message);
            }

            try
            {
                if (m1.m.GetLength(0) != m2.m.GetLength(1))
                {
                    throw new GenricMatrixException("Matrix multiplication requires same rows of 1st matrices and same columns of the 2nd matrcies.");
                }
                
                GenricMatrix<int> mul = new GenricMatrix<int>(m1.Rows, m2.Cols);
                mul.Multiply(m1.m, m2.m);
                
                Console.WriteLine("Multiplication :- ");
                mul.getMatrix();

            }
            catch (Exception ex)
            {
                Console.WriteLine("matrix operation failed:" + ex.Message);

            }

            Console.Write("enter 7485 for exit :-");
            Int32 exit = Convert.ToInt32(Console.ReadLine());

            if(exit!=7485)
            goto input;
        }
    }
}
