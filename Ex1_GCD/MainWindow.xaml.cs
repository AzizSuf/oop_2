// Задание 1.Вычислить наибольший общий делитель двух целых чисел с помощью алгоритма Евклида
// Задание 2. Вычислить наибольший общий делитель 3,4,5 чисел

using System;
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
            bool isEntered1 = int.TryParse(number1TextBox.Text, out int num1);
            bool isEntered2 = int.TryParse(number2TextBox.Text, out int num2);
            bool isEntered3 = int.TryParse(number3TextBox.Text, out int num3);
            bool isEntered4 = int.TryParse(number4TextBox.Text, out int num4);
            bool isEntered5 = int.TryParse(number5TextBox.Text, out int num5);

            gcdEuclidTimeLabel.Content = "UNS"; // Unsupported value
            gcdSteinResultLabel.Content = "UNS";
            gcdSteinTimeLabel.Content = "UNS";

            if (isEntered1 && isEntered2 && isEntered3 && isEntered4 && isEntered5)
            {
                gcdEuclidResultLabel.Content = GCDAlgorithms.FindGCDEuclid(num1, num2, num3, num4, num5);
            }
            else if (isEntered1 && isEntered2 && isEntered3 && isEntered4)
            {
                gcdEuclidResultLabel.Content = GCDAlgorithms.FindGCDEuclid(num1, num2, num3, num4);
            }
            else if (isEntered1 && isEntered2 && isEntered3)
            {
                gcdEuclidResultLabel.Content = GCDAlgorithms.FindGCDEuclid(num1, num2, num3);
            }
            else if (isEntered1 && isEntered2)
            {
                gcdEuclidResultLabel.Content = GCDAlgorithms.FindGCDEuclid(num1, num2);
                gcdEuclidTimeLabel.Content = TestTimeExecution(num1, num2, GCDAlgorithms.FindGCDEuclid);

                gcdSteinResultLabel.Content = GCDAlgorithms.FindGCDStein(num1, num2);
                gcdSteinTimeLabel.Content = TestTimeExecution(num1, num2, GCDAlgorithms.FindGCDStein);
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
