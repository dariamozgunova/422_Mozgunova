using System;
using System.Collections.Generic;
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

namespace _422_Mozgunova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCalculator(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(input_x.Text) || string.IsNullOrWhiteSpace(input_p.Text))
            {
                MessageBox.Show("Поля x и/или p НЕ заполнены значениями, поэтому вычисление невозможно!");
                return;
            }

            if (!double.TryParse(input_x.Text, out double x))
            {
                MessageBox.Show("Некорректное значение x");
                return;
            }

            if (!double.TryParse(input_p.Text, out double p))
            {
                MessageBox.Show("Некорректное значение p");
                return;
            }

            double fx;
            if (radioSh.IsChecked == true)
            {
                fx = Math.Sinh(x);
            }
            else if (radioX2.IsChecked == true)
            {
                fx = Math.Pow(x, 2);
            }
            else
            {
                fx = Math.Exp(x);
            }

            double abs_p = Math.Abs(p);
            double l = 0;
            if (x >  abs_p) 
            {
                l = 2 * Math.Pow(fx, 3) + 3 * Math.Pow(p, 2);
            }
            else if (x > 3 && x < abs_p)
            {
                l = Math.Abs(fx - p);
            }
            else
            {
                l = Math.Pow(fx - p, 2);
            }
            result.Text = l.ToString();
        }

        private void ButtonClear(object sender, RoutedEventArgs e)
        {
            input_x.Text = "";
            input_p.Text = "";
            result.Text = "";
            radioSh.IsChecked = true;
        }

        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
