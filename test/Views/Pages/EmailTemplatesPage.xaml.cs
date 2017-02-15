using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ElibriumWPF.ViewModel;
using System.ComponentModel;
using static ElibriumWPF.Util.Filter;

namespace Elibrium.Views
{
    /// <summary>
    /// Interaction logic for EmailPage.xaml
    /// </summary>
    public partial class EmailTemplatesPage : Page
    {
        private EmailTemplatesPageVM _vm;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public EmailTemplatesPage()
        {
            InitializeComponent();
            this._vm = new EmailTemplatesPageVM();
            this.DataContext = _vm;
            List<string> st = new List<string> { "Offer Template", "Birthday Template" };
            comboBox.ItemsSource = st;
            comboBox.SelectedIndex = 1;
        }

        private void lvEmails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;

        }

        private void lvColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (e.OriginalSource as GridViewColumnHeader);
            if (column.Tag != null) {
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
            }
            e.Handled = true;
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

