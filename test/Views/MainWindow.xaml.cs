using System.Windows;
using ElibriumWPF.ViewModel;
using System;
using System.Windows.Controls;
using System.Text;
using System.ComponentModel;
using System.Windows.Documents;
using static ElibriumWPF.Util.Filter;
using Elibrium.BO;

namespace Elibrium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientsPageVM _vm;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public static string Theme = "wrrw";
        public static string Colour = "LightBlue";

        public MainWindow()
        {
            this._vm = new ClientsPageVM();
            this.DataContext = this._vm;
            InitializeComponent();
            ContactTypeBO.AddEmail();
            _vm.SendBirthDayMails();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (e.Source is TabControl)
            {
                string tabName = ((TabItem)tabControl.SelectedItem).Name;
                string errorFormat = "You need to add a {0} before you can start working with {1}";

                if (tabName.Equals(Persons.Name) && this._vm.Clients.Count < 1)
                {
                    MessageBoxResult result = MessageBox.Show(String.Format(errorFormat, "Client", tabName), "Warning");
                }
                else if (tabName.Equals(Offers.Name) && this._vm.AllPersons.Count < 1)
                {
                    MessageBoxResult result = MessageBox.Show(String.Format(errorFormat, "Person", tabName), "Warning");
                    ((TabControl)e.Source).Focusable = false;
                }
                else
                {
                    StringBuilder sb = new StringBuilder("Pages/");
                    sb.Append(tabName);
                    sb.Append("Page.xaml");
                    clientFrame.Source = new Uri(sb.ToString(), UriKind.Relative);
                    clientFrame.UpdateLayout();
                }
            }
            e.Handled = true;
        }

        public void lvColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (e.OriginalSource as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                (sender as ListView).Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            (sender as ListView).Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
            e.Handled = true;
        }


    }
}
