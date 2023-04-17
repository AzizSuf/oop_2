using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatrixMultiplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dataTable1;
        DataTable dataTable2;
        DataTable resultDataTable;

        int[,] matrix1;
        int[,] matrix2;
        int[,] result;

        public MainWindow()
        {
            InitializeComponent();
        }



        private void CreateDataTable(DataTable dt, int rows, int cols)
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

        private void RandomFillDataTable(DataTable dt)
        {
            Random rand = new Random();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dt.Rows[i][j] = rand.Next(0, 300);
                }
            }
        }

        private void createMatrix1Button_Click(object sender, RoutedEventArgs e)
        {
            dataTable1 = new DataTable();
            int rows = 0;
            int cols = 0;

            if (!int.TryParse(rowsMatrix1TextBox.Text, out rows) || !int.TryParse(colsMatrix1TextBox.Text, out cols))
            {
                MessageBox.Show("Error");
            }

            CreateDataTable(dataTable1, rows, cols);
            matrix1DataGrid.ItemsSource = dataTable1.DefaultView;

            matrix1 = new int[rows, cols];
        }

        private void randomMatrix1Button_Click(object sender, RoutedEventArgs e)
        {
            RandomFillDataTable(dataTable1);
            matrix1DataGrid.ItemsSource = dataTable1.DefaultView;
        }

        private void createMatrix2Button_Click(object sender, RoutedEventArgs e)
        {
            dataTable2 = new DataTable();
            int rows = 0;
            int cols = 0;

            if (!int.TryParse(rowsMatrix2TextBox.Text, out rows) || !int.TryParse(colsMatrix2TextBox.Text, out cols))
            {
                MessageBox.Show("Error");
            }

            CreateDataTable(dataTable2, rows, cols);
            matrix2DataGrid.ItemsSource = dataTable2.DefaultView;
            matrix2 = new int[rows, cols];
        }

        private void randomMatrix2Button_Click(object sender, RoutedEventArgs e)
        {
            RandomFillDataTable(dataTable2);
            matrix2DataGrid.ItemsSource = dataTable2.DefaultView;
        }

        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = Convert.ToInt32(dataTable1.Rows[i][j]);
                }
            }

            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = Convert.ToInt32(dataTable2.Rows[i][j]);
                }
            }

            try
            {
                result = Matrix.MatrixMultiply(matrix1, matrix2);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            resultDataTable = new DataTable();
            CreateDataTable(resultDataTable, result.GetLength(0), result.GetLength(1));
            
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    resultDataTable.Rows[i][j] = result[i, j];
                }
            }

            resultDataGrid.ItemsSource = resultDataTable.DefaultView;
        }
    }
}
