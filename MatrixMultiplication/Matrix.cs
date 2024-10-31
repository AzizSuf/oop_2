using System;
using System.Collections;

namespace MatrixMultiplication
{
    public class Matrix
    {
        private int[,] _data;
        public int Rows { get { return _data.GetLength(0); } }
        public int Cols { get { return _data.GetLength(1); } }

        public Matrix(int rows, int cols)
        {
            _data = new int[rows, cols];
        }

        public Matrix(int rows, int cols, int initializer) : this(rows, cols)
        {
            for (int i = 0; i < _data.GetLength(0); i++)
            {
                for (int j = 0; j < _data.GetLength(1); j++)
                {
                    _data[i, j] = initializer;
                }
            }
        }

        public Matrix(int rows, int cols, IEnumerable initializer) : this(rows, cols)
        {
            var iter = initializer.GetEnumerator();

            for (int i = 0; i < _data.GetLength(0); i++)
            {
                for (int j = 0; j < _data.GetLength(1); j++)
                {
                    iter.MoveNext();
                    _data[i, j] = Convert.ToInt32(iter.Current);
                }
            }
        }

        public static Matrix operator* (Matrix lhs, Matrix rhs)
        {
            var res = new Matrix(lhs.Rows, rhs.Cols);
            
            if (lhs.Cols != rhs.Rows)
            {
                throw new ArgumentException("The number of columns in the first matrix must be equal to the number of rows in the second matrix");
            }

            for (int i = 0; i < res.Rows; i++)
            {
                for (int j = 0; j < res.Cols; j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < lhs.Cols; k++)
                    {
                        res[i, j] += lhs[i, k] * rhs[k, j];
                    }
                }
            }

            return res;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Matrix other)
            {
                if (this.Rows != other.Rows || this.Cols != other.Cols) return false;

                for (int i = 0; i < this.Rows; i++)
                {
                    for (int j = 0; j < this.Cols; j++)
                    {
                        if (this[i, j] != other[i, j]) return false;
                    }
                }
                return true;
            }
            return false;
        }

        // TODO ????
        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(_data);
        //}

        public int this[int i, int j]
        {
            get => _data[i, j];
            set => _data[i, j] = value;
        }

        public IEnumerator GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}
