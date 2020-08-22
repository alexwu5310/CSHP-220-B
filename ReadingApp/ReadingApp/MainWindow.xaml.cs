using ReadingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ReadingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListSortDirection SortDirection = ListSortDirection.Ascending;
        GridViewColumnHeader CurrentHeader = null;

        public MainWindow()
        {
            InitializeComponent();

            LoadReading();

            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(uxListHeader_onclick));


        }

        private ReadingModel selectedReading;

        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedReading = (ReadingModel)uxReadingList.SelectedValue;
        }

        private void LoadReading()
        {
            var contacts = App.ReadingRepository.GetAll();

            uxReadingList.ItemsSource = contacts
                .Select(t => ReadingModel.ToModel(t))
                .ToList();

            // OR
            //var uiContactModelList = new List<ContactModel>();
            //foreach (var repositoryContactModel in contacts)
            //{
            //    This is the .Select(t => ... )
            //    var uiContactModel = ContactModel.ToModel(repositoryContactModel);
            //
            //    uiContactModelList.Add(uiContactModel);
            //}

            //uxContactList.ItemsSource = uiContactModelList;
        }
        private void uxListHeader_onclick(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource.GetType().Name != "RadioButton") 
            {
                var headerClicked = e.OriginalSource as GridViewColumnHeader;
                var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxReadingList.ItemsSource);

                ListSortDirection newDir = ListSortDirection.Ascending;
                if (headerClicked == CurrentHeader && SortDirection == newDir)
                { newDir = ListSortDirection.Descending; }

                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(sortBy, newDir));
                view.Refresh();
                SortDirection = newDir;
                CurrentHeader = headerClicked;
            }
        }

        private void uxAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddReadingWindow();

            if (window.ShowDialog() == true)
            {
                var uiReadingModel = window.Reading;
                var repositoryReadingModel = uiReadingModel.ToRepositoryModel();
                App.ReadingRepository.Add(repositoryReadingModel);
                LoadReading();
            }
        }

        private void uxModify_Click(object sender, RoutedEventArgs e)
        {
            ModifyReading();
        }

        private void ModifyReading()
        {
            var window = new AddReadingWindow();
            window.Reading = selectedReading.Clone();

            if (window.ShowDialog() == true)
            {
                App.ReadingRepository.Update(window.Reading.ToRepositoryModel());
                LoadReading();
            }
        }

        private void uxModify_Loaded(object sender, RoutedEventArgs e)
        {
            uxModify.IsEnabled = (selectedReading != null);
            uxContextModify.IsEnabled = uxModify.IsEnabled;
        }

        private void uxDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ReadingRepository.Remove(selectedReading.Id);
            selectedReading = null;
            LoadReading();
        }

        private void uxDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxDelete.IsEnabled = (selectedReading != null);
            uxContextDelete.IsEnabled = uxDelete.IsEnabled;
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void uxReadingList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ModifyReading();
        }

        private void uxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string myString = uxSearch.Text;
            LoadReading();
            if (myString.Length != 0)
            {
                List<ReadingModel> readingList = uxReadingList.ItemsSource.Cast<ReadingModel>().ToList();
                if (uxTitle.IsChecked.Value)
                {
                    readingList.RemoveAll(reading => reading.compareTitleText(myString) == false);
                }
                else
                {
                    readingList.RemoveAll(reading => reading.compareAuthorText(myString) == false);
                }
                uxReadingList.ItemsSource = readingList;
            }
        }
    }
}
