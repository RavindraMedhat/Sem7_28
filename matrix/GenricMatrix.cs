using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    public class GenricMatrix<T> where T : struct
    {
        public T[,] m;

        public int Rows;
        public int Cols;
       
        public GenricMatrix(int rows, int cols)
        {
            m = new T[rows, cols];
            Rows = rows;
            Cols = cols;
        }

        public void setMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    m[i, j] = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
            }
        }

        public void getMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
        }


        public void Addition(T[,] a, T[,] b)
        {

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    dynamic value1 = a[i, j];
                    dynamic value2 = b[i, j];
                    this.m[i, j] = value1 + value2;
                }
            }

        }

        public void Substraction(T[,] a, T[,] b)
        {

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    dynamic value1 = a[i, j];
                    dynamic value2 = b[i, j];
                    this.m[i, j] = value1 - value2;
                }
            }

        }

        public void Multiply(T[,] a, T[,] b)
        {
            int rows = a.GetLength(0);
            int columns = b.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < columns; k++)
                    {
                        this.m[i, j] += (dynamic)a[i, k] * (dynamic)b[k, j];
                    }
                }
            }
        }

        //static T[,] InvertMatrix(T[,] matrix)
        //{
        //    int n = matrix.GetLength(0);
        //    T[,] identity = new T[n, n];
        //    T[,] augmentedMatrix = new T[n, 2 * n];

        //    // Initialize the identity matrix
        //    for (int i = 0; i < n; i++)
        //    {
        //        identity[i, i] = (T)Convert.ChangeType(1, typeof(T));
        //    }

        //    // Create the augmented matrix [matrix | identity]
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            augmentedMatrix[i, j] = matrix[i, j];
        //            augmentedMatrix[i, j + n] = identity[i, j];
        //        }
        //    }

        //    // Gaussian elimination to transform [matrix | identity] into [identity | inverted_matrix]
        //    for (int i = 0; i < n; i++)
        //    {
        //        T diagonal = augmentedMatrix[i, i];
        //        for (int j = i; j < 2 * n; j++)
        //        {
        //            augmentedMatrix[i, j] /= diagonal;
        //        }

        //        for (int k = 0; k < n; k++)
        //        {
        //            if (k != i)
        //            {
        //                double factor = augmentedMatrix[k, i];
        //                for (int j = i; j < 2 * n; j++)
        //                {
        //                    augmentedMatrix[k, j] -= factor * augmentedMatrix[i, j];
        //                }
        //            }
        //        }
        //    }

        //    // Extract the right side of the augmented matrix as the inverted matrix
        //    double[,] invertedMatrix = new double[n, n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            invertedMatrix[i, j] = augmentedMatrix[i, j + n];
        //        }
        //    }

        //    return invertedMatrix;
        //}

    }
}
