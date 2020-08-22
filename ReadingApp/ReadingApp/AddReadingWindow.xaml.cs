using ReadingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReadingApp
{
    /// <summary>
    /// Interaction logic for AddReadingWindow.xaml
    /// </summary>
    public partial class AddReadingWindow : Window
    {
        public AddReadingWindow()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public ReadingModel Reading { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Reading != null)
            {
                if (Reading.Type == "Mysteries")
                {
                    uxMysteries.IsChecked = true;
                }
                else if(Reading.Type == "Romance")
                {
                    uxRomance.IsChecked = true;
                }
                else if(Reading.Type == "Thrillers")
                {
                    uxThrillers.IsChecked = true;
                }
                else if(Reading.Type == "Scifi")
                {
                    uxScifi.IsChecked = true;
                }
                else if(Reading.Type == "Fantasy")
                {
                    uxFantasy.IsChecked = true;
                }
                else
                {
                    uxHistorical.IsChecked = true;
                }
                uxSubmit.Content = "Update";
            }
            else
            {
                Reading = new ReadingModel();
                Reading.ModifiedDate = DateTime.Now;
            }

            uxGrid.DataContext = Reading;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (uxMysteries.IsChecked.Value)
            {
                Reading.Type = "Mysteries";
            }
            else if (uxRomance.IsChecked.Value)
            {
                Reading.Type = "Romance";
            }
            else if (uxThrillers.IsChecked.Value)
            {
                Reading.Type = "Thrillers";
            }
            else if (uxScifi.IsChecked.Value)
            {
                Reading.Type = "Scifi";
            }
            else if (uxFantasy.IsChecked.Value)
            {
                Reading.Type = "Fantasy";
            }
            else
            {
                Reading.Type = "Historical";
            }

            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }
    }
}
