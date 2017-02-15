using System;
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
    /// Interaction logic for PositionTypePage.xaml
    /// </summary>
    public partial class PositionTypePage : Page
    {
        private PositionTypePageVM _vm;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public PositionTypePage()
        {
            this._vm = new PositionTypePageVM();
            this.DataContext = this._vm;
            InitializeComponent();
            if (_vm.PositionTypes.Count != 0)
            {
                _vm.GetPositionTypes();
                lvPositionTypes.ItemsSource = _vm.PositionTypes;
                lvPositionTypes.UpdateLayout();
            }
        }

        private void lvPositionTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PositionTypeBO ctbo = lvPositionTypes.SelectedItem as PositionTypeBO;
            if (ctbo != null)
            {
                txtPositionTypeName.Text = ctbo.Name;
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

        private void btnAddPositionType_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "Contact Type name can not be {0}";
            if (!txtPositionTypeName.Text.Equals(""))
            {
                if (txtPositionTypeName.Text.Length > 32)
                {
                    MessageBox.Show(String.Format(errorMsg, "longer than 32"), "Warning", MessageBoxButton.OK);
                }
                else
                {
                    PositionTypeBO bo = new PositionTypeBO(txtPositionTypeName.Text);
                    bo.AddOrUpdate();
                    lvPositionTypes.ItemsSource = _vm.PositionTypes;
                    lvPositionTypes.UpdateLayout();
                }
            }
            else
            {
                MessageBox.Show(String.Format(errorMsg, "empty"), "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void btnDeletePositionType_Click(object sender, RoutedEventArgs e)
        {
            var ptc = lvPositionTypes.SelectedItems;
            if (ptc.Count > 0)
            {
                foreach (PositionTypeBO bo in ptc)
                {
                    if (!bo.InUse)
                    {
                        bo.Delete();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Can not delete Position Type, as it is in use", "Warning", MessageBoxButton.OK);
                    }
                }
                lvPositionTypes.ItemsSource = _vm.PositionTypes;
                lvPositionTypes.UpdateLayout();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Select a Position Type to delete first", "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void btnSavePositionType_Click(object sender, RoutedEventArgs e)
        {
            if (lvPositionTypes.SelectedItem != null)
            {
                PositionTypeBO bo = new PositionTypeBO((lvPositionTypes.SelectedItem as PositionTypeBO).Id, txtPositionTypeName.Text);
                bo.AddOrUpdate();
                lvPositionTypes.ItemsSource = _vm.PositionTypes;
                lvPositionTypes.UpdateLayout();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Select a Contact Type to edit first", "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void txtPositionTypeName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
