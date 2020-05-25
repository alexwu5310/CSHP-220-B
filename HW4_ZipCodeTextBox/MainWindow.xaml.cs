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

namespace HW4_ZipCodeTextBox
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

        private void uxZip_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (uxZip.Text.Length == 10)
            {
                e.Handled = true;
            }
        }

        private void EnableSubmit()
        {
            uxWrongFormat.Visibility = Visibility.Hidden;
            uxSubmit.IsEnabled = true;
        }
        private void DisableSubmit()
        {
            uxWrongFormat.Visibility = Visibility.Visible;
            uxSubmit.IsEnabled = false;
        }

        private bool AreAllValidNumericChars(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsNumber(c)) return false;
            }

            return true;
        }

        private bool IsCAPostCode(string str)
        {
            int index = 0;
            foreach (char c in str)
            {
                if (index % 2 == 0)
                {
                    if (!char.IsLetter(c) || char.IsLower(c)) return false;
                }
                else
                {
                    if (!char.IsNumber(c)) return false;
                }
                index++;
            }

            return true;
        }

        private void uxZip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxZip.Text.Length == 5)//US part zip
            {
                if (AreAllValidNumericChars(uxZip.Text))
                {
                    EnableSubmit();
                }
                else
                {
                    DisableSubmit();
                }
            }
            else if (uxZip.Text.Length == 6) //CA Post Code
            {

                if (IsCAPostCode(uxZip.Text)) 
                {
                    EnableSubmit();
                }
                else
                {
                    DisableSubmit();
                }
            }
            else if (uxZip.Text.Length == 10) //Us full zip
            {
                if (uxZip.Text[5] == '-')
                {
                    string myString = uxZip.Text;
                    if (AreAllValidNumericChars(myString.Remove(5, 1)))
                    {
                        EnableSubmit();
                    }
                }
                else
                {
                    DisableSubmit();
                }
            }
            else
            {
                DisableSubmit();
            }
        }
    }
}
