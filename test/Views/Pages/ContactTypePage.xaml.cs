using System.Windows;
using System.Windows.Controls;
using ElibriumWPF.ViewModel;
using Elibrium.BO;
using System.ComponentModel;
using System.Windows.Documents;
using static ElibriumWPF.Util.Filter;

namespace ElibriumWPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for ContactTypePage.xaml
    /// </summary>
    public partial class ContactTypePage : Page
    {
        private ContactTypePageVM _vm;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public ContactTypePage()
        {
            this._vm = new ContactTypePageVM();
            this.DataContext = this._vm;
            InitializeComponent();
            if (_vm.ContactTypes.Count != 0)
            {
                lvContactTypes.ItemsSource = _vm.ContactTypes;
                lvContactTypes.UpdateLayout();
            }
        }

        private void lvContactTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContactTypeBO ctbo = lvContactTypes.SelectedItem as ContactTypeBO;
            if (ctbo != null)
            {
                txtContactTypeName.Text = ctbo.Name;
            }
            e.Handled = true;
        }

        private void lvColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (e.OriginalSource as GridViewColumnHeader);
            if (column.Tag != null)
            {
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

        private void btnAddContactType_Click(object sender, RoutedEventArgs e)
        {
            if (!txtContactTypeName.Text.Equals(""))
            {
                if (txtContactTypeName.Text.Length > 32)
                {
                    MessageBoxResult result = MessageBox.Show("Contact Type name can not be longer than 32", "Warning", MessageBoxButton.OK);
                }
                else
                {
                    ContactTypeBO bo = new ContactTypeBO(txtContactTypeName.Text);
                    bo.AddOrUpdate();
                    lvContactTypes.ItemsSource = _vm.ContactTypes;
                    lvContactTypes.UpdateLayout();
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Contact Type name can not be empty", "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void btnDeleteContactType_Click(object sender, RoutedEventArgs e)
        {
            var ctc = lvContactTypes.SelectedItems;
            if (ctc.Count > 0)
            {
                foreach (ContactTypeBO bo in ctc)
                {
                    if (!bo.InUse)
                    {
                        if (bo.Id != 1)
                        {
                            bo.Delete();
                        }
                        else
                        {
                            MessageBoxResult result = MessageBox.Show("Can not delete Email, as it is mandatory", "Warning", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Can not delete Contact Type, as it is in use", "Warning", MessageBoxButton.OK);
                    }
                }
                lvContactTypes.ItemsSource = _vm.ContactTypes;
                lvContactTypes.UpdateLayout();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Select a Contact Type to delete first", "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void btnSaveContactType_Click(object sender, RoutedEventArgs e)
        {
            if (lvContactTypes.SelectedItem != null)
            {
                ContactTypeBO bo = new ContactTypeBO((lvContactTypes.SelectedItem as ContactTypeBO).Id, txtContactTypeName.Text);
                bo.AddOrUpdate();
                lvContactTypes.ItemsSource = _vm.ContactTypes;
                lvContactTypes.UpdateLayout();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Select a Contact Type to edit first", "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void txtContactTypeName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
