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

namespace HW5Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char curPlayer = 'X';
        private int turns = 0;
        private char[] boardRow0 = new char[3];
        private char[] boardRow1 = new char[3];
        private char[] boardRow2 = new char[3];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            curPlayer = 'X';
            uxTurn.Text = curPlayer + "'s turn";
            turns = 0;
            for(int i = 0; i < boardRow0.Length; i++)
            {
                boardRow0[i] = ' ';
            }
            for (int i = 0; i < boardRow1.Length; i++)
            {
                boardRow1[i] = ' ';
            }
            for (int i = 0; i < boardRow2.Length; i++)
            {
                boardRow2[i] = ' ';
            }
            Button[] myBtns = uxGrid.Children.OfType<Button>().ToArray();

            foreach(Button btn in myBtns) 
            {
                btn.Content = "";
            }
            uxGrid.IsEnabled = true;
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             //MessageBox.Show((sender as Button).Tag.ToString());
            //Mark selected grid if condition is met, also alter player's turn
            if ((sender as Button).Content == null || (sender as Button).Content.ToString() == "") 
            {
                (sender as Button).Content = curPlayer;
                string locationTag = (sender as Button).Tag.ToString();
                //check win condition
                if (checkWinCondition(locationTag))//Player won
                {
                    uxGrid.IsEnabled = false;
                    uxTurn.Text = curPlayer + " is a winner";
                }
                else //Game continue
                {
                    if(turns < 8) 
                    {
                        if (curPlayer == 'X')
                        {
                            curPlayer = 'O';
                        }
                        else
                        {
                            curPlayer = 'X';
                        }
                        uxTurn.Text = curPlayer + "'s turn";
                        turns++;
                    }
                    else //Draw
                    {
                        uxGrid.IsEnabled = false;
                        uxTurn.Text = "Is a Draw";
                    }
                }
            }

        }

        private bool checkWinCondition(string tag) 
        {
            char row = tag[0];
            int col = int.Parse(tag.Substring(2));
            //MessageBox.Show(row.ToString() + col.ToString());
            switch (row)
            {
                case '0':
                    boardRow0[col] = curPlayer;
                    if (boardRow1[col] == curPlayer && boardRow2[col] == curPlayer)// check col
                    {
                        return true;
                    }
                    if (col == 0)
                    {
                        if (boardRow0[1] == curPlayer && boardRow0[2] == curPlayer) //check row
                        {
                            return true;
                        }
                        if (boardRow1[1] == curPlayer && boardRow2[2] == curPlayer) //check diagonal
                        {
                            return true;
                        }
                    }
                    else if(col == 2) 
                    {
                        if (boardRow0[0] == curPlayer && boardRow0[1] == curPlayer) //check row
                        {
                            return true;
                        }
                        if (boardRow1[1] == curPlayer && boardRow2[0] == curPlayer) //check diagonal
                        {
                            return true;
                        }
                    }
                    else //col = 1
                    {
                        if (boardRow0[0] == curPlayer && boardRow0[2] == curPlayer) //check row
                        {
                            return true;
                        }
                    }
                    return false;

                case '1':
                    boardRow1[col] = curPlayer;
                    if (boardRow0[col] == curPlayer && boardRow2[col] == curPlayer)// check col
                    {
                        return true;
                    }
                    if (col == 1)
                    {
                        if (boardRow1[0] == curPlayer && boardRow1[2] == curPlayer) //check row
                        {
                            return true;
                        }
                        if (boardRow0[0] == curPlayer && boardRow2[2] == curPlayer) //check diagonal
                        {
                            return true;
                        }

                        if (boardRow0[2] == curPlayer && boardRow2[0] == curPlayer) //check diagonal
                        {
                            return true;
                        }
                    }
                    else //col = 0 or 2
                    {
                        if (boardRow1[0] == curPlayer && boardRow1[1] == curPlayer &&  boardRow1[2] == curPlayer) //check row
                        {
                            return true;
                        }
                    }
                    return false;

                case '2':
                    boardRow2[col] = curPlayer;
                    if (boardRow0[col] == curPlayer && boardRow1[col] == curPlayer)// check col
                    {
                        return true;
                    }
                    if (col == 0)
                    {
                        if (boardRow2[1] == curPlayer && boardRow2[2] == curPlayer) //check row
                        {
                            return true;
                        }
                        if (boardRow1[1] == curPlayer && boardRow0[2] == curPlayer) //check diagonal
                        {
                            return true;
                        }
                    }
                    else if (col == 2)
                    {
                        if (boardRow2[0] == curPlayer && boardRow2[1] == curPlayer) //check row
                        {
                            return true;
                        }
                        if (boardRow1[1] == curPlayer && boardRow0[0] == curPlayer) //check diagonal
                        {
                            return true;
                        }
                    }
                    else //col = 1
                    {
                        if (boardRow2[0] == curPlayer && boardRow2[2] == curPlayer) //check row
                        {
                            return true;
                        }
                    }
                    return false;

                default:
                    Console.WriteLine("invalid row");
                    return false;
            }
        }
    }
}
