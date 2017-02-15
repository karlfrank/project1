using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ElibriumWPF.ViewModel;
using Elibrium.BO;
using System.ComponentModel;
using System.Collections.ObjectModel;
using static ElibriumWPF.Util.Filter;

namespace ElibriumWPF.Views
{
    /// <summary>
    /// Interaction logic for OffersPage.xaml
    /// </summary>
    public partial class OffersPage : Page
    {
        private OffersPageVM _vm;
        public OffersPage()
        {
            this._vm = new OffersPageVM();
            this.DataContext = this._vm;
            InitializeComponent();
            lvOffers.ItemsSource = _vm.Offers;
            lvOffers.UpdateLayout();
            lvCustomers.ItemsSource = new ObservableCollection<PersonOfferBO>();
            lvCustomers.UpdateLayout();
            cBoxStatuses.ItemsSource = _vm.Statuses;
            cBoxStatuses.SelectedIndex = 1;
            cBoxCustomers.ItemsSource = _vm.Customers;
            if (_vm.Customers.Count > 0)
            {
                cBoxCustomers.SelectedIndex = 0;
            }
            cBoxCustomers.UpdateLayout();
        }

        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        private void lvOffers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvOffers.UpdateLayout();
            if (lvOffers.SelectedItem != null)
            {
                OfferBO offer = lvOffers.SelectedItem as OfferBO;
                txtContent.Text = offer.Description;
                txtTitle.Text = offer.Title;
                dateFrom.Text = offer.DateFrom.ToString();
                dateTo.Text = offer.DateTo.ToString();
                lvCustomers.ItemsSource = offer.PersonOffers;
                lvCustomers.UpdateLayout();
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


        private void txtTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDeleteOffer_Click(object sender, RoutedEventArgs e)
        {
            var offers = lvOffers.SelectedItems;
            if (offers.Count > 0)
            {
                foreach (OfferBO bo in offers)
                {
                    if (bo.PersonOffers.Count() > 0)
                    {
                        MessageBoxResult result = MessageBox.Show("You can not delete a Offer, that has Customers, the clients need to be migrated first", "A big fat warning", MessageBoxButton.OK);
                    }
                    else
                    {
                        bo.Delete();
                    }
                }
                lvOffers.ItemsSource = _vm.Offers;
                lvOffers.UpdateLayout();
            }
        }

        private void btnEditOffer_Click(object sender, RoutedEventArgs e)
        {
            if (lvOffers.SelectedItem != null)
            {
                add((lvOffers.SelectedItem as OfferBO).Id, txtTitle.Text, txtContent.Text, dateFrom.SelectedDate.ToString(), dateTo.SelectedDate.ToString());
            }
        }

        private void add(int id, string title, string desc, string from, string to)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            DateTime dt2 = new DateTime(1900, 1, 1);
            try
            {
                dt = DateTime.Parse(from.ToString());
                dt2 = DateTime.Parse(to.ToString());
            }
            catch
            {

            }
            new OfferBO(id, txtTitle.Text, txtContent.Text, dt, dt2).AddOrUpdate();
            lvOffers.ItemsSource = _vm.Offers;
            lvOffers.UpdateLayout();
        }

        private void btnAddOffer_Click(object sender, RoutedEventArgs e)
        {
            add(0, txtTitle.Text, txtContent.Text, dateFrom.SelectedDate.ToString(), dateTo.SelectedDate.ToString());
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (cBoxCustomers.SelectedItem != null && lvOffers.SelectedItem != null)
            {
                string status = "missing";
                if (cBoxStatuses.SelectedItem != null)
                {
                    status = cBoxStatuses.SelectedItem.ToString();
                }
                PersonOfferBO cHasOffer = new PersonOfferBO((lvOffers.SelectedItem as OfferBO).Id, (cBoxCustomers.SelectedItem as PersonBO).Id, status);
                cHasOffer.AddOrUpdate();
                lvCustomers.ItemsSource = (lvOffers.SelectedItem as OfferBO).PersonOffers;
                lvCustomers.UpdateLayout();
            }
        }
        private void btnRemoveCustomer_Click(object sender, RoutedEventArgs e)
        {
            var persons = lvCustomers.SelectedItems;
            if (persons.Count > 0)
            {
                foreach (PersonOfferBO person in persons)
                {
                    person.Delete();
                }
                lvCustomers.ItemsSource = (lvOffers.SelectedItem as OfferBO).PersonOffers;
                lvCustomers.UpdateLayout();
            }
        }

        private void lvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCustomers.SelectedItem != null)
            {
                string status = (lvCustomers.SelectedItem as PersonOfferBO).Status;
                if (_vm.Statuses.Contains(status))
                {
                    cBoxStatuses.Text = status;
                }
            }
        }

        private void cBoxStatus_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cBoxStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ShowPersonDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEditStatus_Click(object sender, RoutedEventArgs e)
        {
            PersonOfferBO selected = lvCustomers.SelectedItem as PersonOfferBO;
            if (selected != null && cBoxStatuses.SelectedItem != null)
            {
                selected._status = cBoxStatuses.SelectedItem.ToString();
                selected.AddOrUpdate();
                if (lvOffers.SelectedItem != null)
                {
                    OfferBO offer = lvOffers.SelectedItem as OfferBO;
                    lvCustomers.ItemsSource = offer.PersonOffers;
                    lvCustomers.UpdateLayout();
                }
            }
        }

        private void btnSendOffer_Click(object sender, RoutedEventArgs e)
        {
            var pobs = lvCustomers.SelectedItems;
            if (pobs.Count > 0)
            {
                foreach (PersonOfferBO pob in pobs)
                {
                    if (_vm.SendOffer(pob))
                    {
                        MessageBox.Show("Success, offer has been sent", "Success", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Technical error, sending the email has failed, please check that the customers would have an email", "Failure", MessageBoxButton.OK);
                    }
                }
            }
        }
    }
}