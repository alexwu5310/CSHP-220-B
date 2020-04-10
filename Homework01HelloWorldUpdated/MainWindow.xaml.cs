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

namespace Homework01HelloWorldUpdated
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

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateSumit();
        }

        private void uxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            updateSumit();
        }

        private void updateSumit()
        {
            if (uxName.Text == "" || uxPassword.Password == "" )
            {
                uxSubmit.IsEnabled = false;
            }
            else
            {
                uxSubmit.IsEnabled = true;
            }
        }
    }
}
