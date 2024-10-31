// Задание 1.Вычислить наибольший общий делитель двух целых чисел с помощью алгоритма Евклида
// Задание 2. Вычислить наибольший общий делитель 3,4,5 чисел

using System;
using System.Collections;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace Ex1_GCD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate int GCDMethod(int a, int b);

        Stopwatch stopWatch;

        public MainWindow()
        {
            InitializeComponent();

            number1TextBox.Text = "";
            number2TextBox.Text = "";
            gcdEuclidResultLabel.Content = "";

            stopWatch = new Stopwatch();
        }

        private float TestTimeExecution(int a, int b, GCDMethod method, int numberExecutions = 100)
        {
            // Вызов метода через делегат возможно медленнее чем простой вызовов
            // Но т.к абсолютное значение скорости нас не сильно интересует,
            // а нас интересует сравнение скрости алгоритмов относительно друг друга,
            // поэтому можем принебреч накладными расходами на вызов делегата в угоду удобства.
            stopWatch.Restart();
            for (int i = 0; i < numberExecutions; i++)
            {
                method(a, b);
            }
            stopWatch.Stop();

            float elapsedTicks = (float)stopWatch.ElapsedTicks / (float)numberExecutions;

            return elapsedTicks;
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            var textValues = new string[] { number1TextBox.Text, number2TextBox.Text, number3TextBox.Text, number4TextBox.Text, number5TextBox.Text };
            
            var numbers = new int[textValues.Length];
            int validCount = 0;
            foreach (var val in textValues)
            {
                if (int.TryParse(val, out int num))
                {
                    numbers[validCount] = num;
                    validCount++;
                }
            }
            Array.Resize<int>(ref numbers, validCount);

            if (numbers.Length == 2)
            {
                gcdEuclidResultLabel.Content = GCDAlgorithms.FindGCDEuclid(numbers[0], numbers[1]);
                gcdEuclidTimeLabel.Content = TestTimeExecution(numbers[0], numbers[1], GCDAlgorithms.FindGCDEuclid);
                gcdSteinResultLabel.Content = GCDAlgorithms.FindGCDStein(numbers[0], numbers[1]);
                gcdSteinTimeLabel.Content = TestTimeExecution(numbers[0], numbers[1], GCDAlgorithms.FindGCDStein);
            }
            else if (numbers.Length > 2)
            {
                gcdEuclidTimeLabel.Content = "UNS"; // Unsupported value
                gcdSteinResultLabel.Content = "UNS";
                gcdSteinTimeLabel.Content = "UNS";
                gcdEuclidResultLabel.Content = GCDAlgorithms.FindGCDEuclid(numbers);
            }
            else
            {
                MessageBox.Show("Input format error");
                return;
            }
        }

        private void RunListButton_Click(object sender, RoutedEventArgs e)
        {
            string[] strNumbers = numbersListTextBox.Text.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);

            int[] numbers;
            try
            {
                numbers = Array.ConvertAll(strNumbers, int.Parse);
            }
            catch (Exception)
            {
                numbersListTextBox.Background = new SolidColorBrush(Color.FromArgb(30, 200, 0, 0));

                MessageBox.Show("Some error occurs while parsing");
                return;
            }

            if (numbers.Length == 0)
            {
                MessageBox.Show("Numbers not entered!");
                return;
            }

            numbersListTextBox.Background = Brushes.White;

            gdcFromListResultLabel.Content = GCDAlgorithms.FindGCDEuclid(numbers);
        }
    }
}
