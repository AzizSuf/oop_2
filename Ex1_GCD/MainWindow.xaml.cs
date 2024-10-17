// Задание 1.Вычислить наибольший общий делитель двух целых чисел с помощью алгоритма Евклида
// Задание 2. Вычислить наибольший общий делитель 3,4,5 чисел

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // Перед замером скорости вызываем метод, чтобы JIT его скомпилировал
            //var _ = method(a, b);

            // Вызов метода через делегат возможно медленнее чем простой вызовов
            // Но т.к абсолютное значение скорости нас не сильно интересует,
            // а нас интересует сравнение скрости алгоритмов относительно друг друга,
            // поэтому можем принебреч накладными расходами на вызов делегата в угоду удобства.
            stopWatch.Restart();
            for (int i = 0; i < numberExecutions; i++)
            {
                int result = method(a, b);
            }
            stopWatch.Stop();

            float elapsedTicks = (float)stopWatch.ElapsedTicks / (float)numberExecutions;

            return elapsedTicks;
        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            int num1, num2, num3, num4, num5;

            bool isEntered1 = int.TryParse(number1TextBox.Text, out num1);
            bool isEntered2 = int.TryParse(number2TextBox.Text, out num2);
            bool isEntered3 = int.TryParse(number3TextBox.Text, out num3);
            bool isEntered4 = int.TryParse(number4TextBox.Text, out num4);
            bool isEntered5 = int.TryParse(number5TextBox.Text, out num5);

            if (isEntered1 && isEntered2 && isEntered3 && isEntered4 && isEntered5)
            {
                gcdEuclidResultLabel.Content = GCDAlgorithms.FindGCDEuclid(num1, num2, num3, num4, num5);
                gcdEuclidTimeLabel.Content = "UNS";

                gcdSteinResultLabel.Content = "UNS";
                gcdSteinTimeLabel.Content = "UNS";
            }

            else if (isEntered1 && isEntered2 && isEntered3 && isEntered4)
            {
                gcdEuclidResultLabel.Content = GCDAlgorithms.FindGCDEuclid(num1, num2, num3, num4);
                gcdEuclidTimeLabel.Content = "UNS";

                gcdSteinResultLabel.Content = "UNS";
                gcdSteinTimeLabel.Content = "UNS";
            }

            else if (isEntered1 && isEntered2 && isEntered3)
            {
                gcdEuclidResultLabel.Content = GCDAlgorithms.FindGCDEuclid(num1, num2, num3);
                gcdEuclidTimeLabel.Content = "UNS";

                gcdSteinResultLabel.Content = "UNS";
                gcdSteinTimeLabel.Content = "UNS";
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

        private void runListButton_Click(object sender, RoutedEventArgs e)
        {
            string[] strNumbers = numbersListTextBox.Text.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

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
