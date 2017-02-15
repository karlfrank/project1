using System.Windows;
using System.Windows.Controls;
using ElibriumWPF.ViewModel;
using Elibrium.BO;
using System.ComponentModel;
using System.Windows.Documents;
using System.Collections.ObjectModel;
using static ElibriumWPF.Util.Filter;

namespace ElibriumWPF.Views

{
    /// <summary>
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private ClientsPageVM _vm;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        public ClientsPage()
        {
            this._vm = new ClientsPageVM();
            this.DataContext = this._vm;
            InitializeComponent();
            if (_vm.Clients.Count != 0)
            {
                lvClients.ItemsSource = _vm.Clients;
                lvClients.SelectedIndex = 0;
                lvClients.UpdateLayout();
                lvOffers.ItemsSource = _vm.GetClientOffers((lvClients.SelectedItem as ClientBO).Id);
                lvOffers.UpdateLayout();
            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text != "")
            {
                lvClients.ItemsSource = _vm.Clients;
            }
            lvClients.UpdateLayout();
            e.Handled = true;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var clients = lvClients.SelectedItems;
            if (clients.Count > 0)
            {
                foreach (ClientBO client in clients)
                {
                    if (client.Persons.Count > 0)
                    {
                        MessageBox.Show("You can not delete a Client, that has Customers, the clients need to be migrated first", "A big fat warning", MessageBoxButton.OK);
                    }
                    else
                    {
                        client.Delete();
                    }
                }
                lvClients.ItemsSource = _vm.Clients;
                searchBox.Text = "";
                lvClients.UpdateLayout();
            }
            e.Handled = true;
        }

        private void add(int id, string firstName, string lastName)
        {
            ClientBO bo = new ClientBO(id, firstName, lastName);
            bo.AddOrUpdate();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (!(txtName.Text.Equals("") || txtBusinessNo.Text.Equals("")))
            {
                add(0, txtName.Text, txtBusinessNo.Text);
                lvClients.ItemsSource = _vm.Clients;
                lvClients.UpdateLayout();
                searchBox.Text = "";
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Add a valid Name, BusinessNO", "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (lvClients.SelectedItem != null)
            {
                ClientBO bo = lvClients.SelectedItem as ClientBO;
                add(bo.Id, txtName.Text, txtBusinessNo.Text);
                lvClients.ItemsSource = _vm.Clients;
                searchBox.Text = "";
                lvClients.UpdateLayout();
                e.Handled = true;
            }
        }

        private void lvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvClients.SelectedItem != null)
            {
                ClientBO a = lvClients.SelectedItem as ClientBO;
                txtName.Text = a.Name;
                txtBusinessNo.Text = a.BusinessNo;
                lvOffers.ItemsSource = _vm.GetClientOffers((lvClients.SelectedItem as ClientBO).Id); lvOffers.UpdateLayout();
            }
            e.Handled = true;
        }


        public void search(object sender, TextChangedEventArgs e)
        {

            if (searchBox.Text != "" && searchBox.Text.Length > 1)
            {
                string str = searchBox.Text;
                ObservableCollection<ClientBO> clts = new ObservableCollection<ClientBO>(_vm.Clients);
                int len = clts.Count;
                ObservableCollection<ClientBO> clts2 = new ObservableCollection<ClientBO>();

                for (int i = 0; i < len; i++)
                {
                    var item = clts[i];

                    if ((item.ToString().Contains(str)))
                    {
                        ClientBO a = item as ClientBO;
                        clts2.Add(a);
                    }
                }
                lvClients.ItemsSource = clts2;
                lvClients.UpdateLayout();
            }
            else
            {
                lvClients.ItemsSource = _vm.Clients;
                lvClients.UpdateLayout();
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
        private void lvContacts_SelectionChanged(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}