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
using System.Windows.Shapes;

namespace DarkRPJobGenerator.Windows
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        public ColorPicker()
        {
            InitializeComponent();
        }
        public Color Color = Colors.Red;

        private void SliderValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte r, g, b;
            r = Convert.ToByte(SliderRed.Value);
            g = Convert.ToByte(SliderGreen.Value);
            b = Convert.ToByte(SliderBlue.Value);
            this.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            TextColor.Text = $"Color({r}, {g}, {b})";
            TextR.Text = r.ToString();
            TextG.Text = g.ToString();
            TextB.Text = b.ToString();
            Color = Color.FromRgb(r, g, b);
        }

        private void TextR_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                byte v = Convert.ToByte(TextR.Text);
                SliderRed.Value = v;
            }
            catch (Exception)
            {
                TextR.Text = "0";
                SliderRed.Value = 0;
            }
        }

        private void TextG_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                byte v = Convert.ToByte(TextG.Text);
                SliderGreen.Value = v;
            }
            catch (Exception)
            {
                TextG.Text = "0";
                SliderGreen.Value = 0;
            }
        }

        private void TextB_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                byte v = Convert.ToByte(TextB.Text);
                SliderBlue.Value = v;
            }
            catch (Exception)
            {
                TextB.Text = "0";
                SliderBlue.Value = 0;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
