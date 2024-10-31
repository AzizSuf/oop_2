using System;
using System.Data;
using System.Linq;
using System.Windows;

namespace MatrixMultiplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable? dataTable1;
        DataTable? dataTable2;

        public MainWindow()
        {
            InitializeComponent();
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
            int rows;
            int cols;

            if (!int.TryParse(rowsMatrix1TextBox.Text, out rows) || !int.TryParse(colsMatrix1TextBox.Text, out cols))
            {
                MessageBox.Show("Enter size");
                return;
            }

            DataTableConverter.CreateDataTable(dataTable1, rows, cols);
            matrix1DataGrid.ItemsSource = dataTable1.DefaultView;
        }

        private void randomMatrix1Button_Click(object sender, RoutedEventArgs e)
        {
            if (dataTable1 == null) return;
            
            RandomFillDataTable(dataTable1);
            matrix1DataGrid.ItemsSource = dataTable1.DefaultView;
        }

        private void createMatrix2Button_Click(object sender, RoutedEventArgs e)
        {
            dataTable2 = new DataTable();
            int rows;
            int cols;

            if (!int.TryParse(rowsMatrix2TextBox.Text, out rows) || !int.TryParse(colsMatrix2TextBox.Text, out cols))
            {
                MessageBox.Show("Error");
                return;
            }

            DataTableConverter.CreateDataTable(dataTable2, rows, cols);
            matrix2DataGrid.ItemsSource = dataTable2.DefaultView;
        }

        private void randomMatrix2Button_Click(object sender, RoutedEventArgs e)
        {
            if (dataTable2 == null) return;

            RandomFillDataTable(dataTable2);
            matrix2DataGrid.ItemsSource = dataTable2.DefaultView;
        }

        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataTable1 == null || dataTable2 == null) return;

            // магия LINQ))
            Matrix matrix1 = new Matrix(dataTable1.Rows.Count, dataTable1.Columns.Count, dataTable1.AsEnumerable().SelectMany(p => p.ItemArray));

            Matrix matrix2 = DataTableConverter.ToMatrix(dataTable2);

            Matrix result;
            try
            {
                result = matrix1 * matrix2;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DataTable resultDataTable = DataTableConverter.FromMatrix(result);

            resultDataGrid.ItemsSource = resultDataTable.DefaultView;
        }
    }
}
