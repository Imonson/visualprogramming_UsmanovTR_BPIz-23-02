using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_rab1_1_UsmanovTR_БПИз_23_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalcArea_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetRoomSizes(out double a, out double b, out double h)) return;

            Room room = new Room(a, b, h);
            double result = room.CalcArea();
            TbResult.Text = $"Площадь стен (вместе с окнами и дверьми): {result:F2} м²";
        }

        private void BtnCalcAreaWithoutWinAndDoors_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetRoomSizes(out double a, out double b, out double h)) return;

            Room room = new Room(a, b, h);
            double result = room.CalcAreaWithoutWindowsAndDoors();

            TbResult.Text = $"Площадь стен (без окна и двери): {result:F2} м²";
        }

        private bool TryGetRoomSizes(out double a, out double b, out double h)
        {
            a = b = h = 0;

            if (!TryParsePositive(TbLength.Text, out a))
            {
                MessageBox.Show("Введите положительную длину (a).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!TryParsePositive(TbWidth.Text, out b))
            {
                MessageBox.Show("Введите положительную ширину (b).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!TryParsePositive(TbHeight.Text, out h))
            {
                MessageBox.Show("Введите положительную высоту (h).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private bool TryParsePositive(string s, out double value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(s)) return false;

            s = s.Trim().Replace(',', '.');

            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double v)) // чтобы парсинг не зависел от настроек системы
            {
                if (v > 0)
                {
                    value = v;
                    return true;
                }
            }
            return false;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!char.IsDigit(e.Text[0]) && e.Text != "." && e.Text != ",")
            {
                e.Handled = true;
                return;
            }

            if ((e.Text == "." || e.Text == ",") &&
                (tb.Text.Contains(",") || tb.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}