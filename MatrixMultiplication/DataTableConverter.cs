using System;
using System.Data;

namespace MatrixMultiplication
{
    internal static class DataTableConverter
    {

        public static void CreateDataTable(DataTable dt, int rows, int cols)
        {
            dt.Reset();
            for (int i = 0; i < rows; i++)
            {
                dt.Rows.Add();
            }
            for (int i = 0; i < cols; i++)
            {
                dt.Columns.Add();
            }
        }

        public static Matrix ToMatrix(DataTable dataTable)
        {
            Matrix matrix = new Matrix(dataTable.Rows.Count, dataTable.Columns.Count);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    matrix[i, j] = Convert.ToInt32(dataTable.Rows[i][j]);
                }
            }

            return matrix;
        }

        public static DataTable FromMatrix(Matrix matrix)
        {
            DataTable dataTable = new DataTable();
            DataTableConverter.CreateDataTable(dataTable, matrix.Rows, matrix.Cols);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    dataTable.Rows[i][j] = matrix[i, j];
                }
            }

            return dataTable;
        }
    }
}