using System;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace DarkRPJobGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string VERSION = "0.1";
        Job CurrentJob;
        public MainWindow()
        {
            InitializeComponent();
            CurrentJob = new Job();
            DataContext = CurrentJob;
            AccessSelector.SelectedIndex = 2;   // Вызовет событие SelectedIndex, что в свою очередь вызовит метод GenerateJob, который сразу сгенерирует скелет профы
        }

        private void AddModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CurrentJob.Models.Add(AddModel.Text);
                AddModel.Text = "";
                GenerateJob();
            }
        }

        private void AddWeapon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CurrentJob.Weapons.Add(AddWeapon.Text);
                AddWeapon.Text = "";
                GenerateJob();
            }
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            var menu = new Windows.ColorPicker();
            if (menu.ShowDialog()==true )
            {
                ColorButton.Background = new SolidColorBrush(menu.Color);
                CurrentJob.Color = menu.Color;
                GenerateJob();
            }
        }

        void GenerateJob()
        {
            TextRange doc = new TextRange(OutTextBox.Document.ContentStart, OutTextBox.Document.ContentEnd);
            doc.Text = CurrentJob.ToString();
        }

        private void RefreshJobText(object sender, RoutedEventArgs e)
        {
            GenerateJob();
        }

        private void AccessSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CurrentJob.Admin = AccessSelector.SelectedIndex;
            GenerateJob();
        }

        private void Vote_Checked(object sender, RoutedEventArgs e)
        {
            CurrentJob.NeedVote = Vote.IsChecked == true;
            GenerateJob();
        }

        private void License_Checked(object sender, RoutedEventArgs e)
        {
            CurrentJob.HasLicense = License.IsChecked == true;
            GenerateJob();
        }

        private void Demote_Checked(object sender, RoutedEventArgs e)
        {
            CurrentJob.CanDemote = Demote.IsChecked == true;
            GenerateJob();
        }
    }
}
