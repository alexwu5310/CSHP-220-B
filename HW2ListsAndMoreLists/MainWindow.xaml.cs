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

namespace HW2ListsAndMoreLists
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            IEnumerable<Models.User> fillteredUsers = users.Where(user => user.Password == "hello");

            //Display to the console, the names of the users where the password is "hello".
            uxList.ItemsSource = fillteredUsers;
            //Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve".
            users.RemoveAll(user => user.Password == user.Name.ToLower());
            //Delete the first User that has the password "hello".
            users.Remove(users.Where(user => user.Password == "hello").First());

            //Display to the console the remaining users with their Name and Password.
            uxList.ItemsSource = users;



        }
    }
}
