using System;

namespace MatrixMultiplication
{
    [Obsolete("Use 'Matrix' class instead")]
    public class MatrixOp
    {
        public static int[,] MatrixMultiply(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
            {
                throw new ArgumentException("The number of columns in the first matrix must be equal to the number of rows in the second matrix");
            }

            int[,] res = new int[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        if (a[i, k] < 0)
                        {
                            throw new ArgumentException($"Matrix1 contains an invalid entry in cell[{i}, {k}].");
                        }
                        if (b[k, j] < 0)
                        {
                            throw new ArgumentException($"Matrix2 contains an invalid entry in cell[{k}, {j}].");
                        }

                        res[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return res;
        }
    }
}
