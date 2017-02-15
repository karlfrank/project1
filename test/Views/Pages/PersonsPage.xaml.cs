using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ElibriumWPF.ViewModel;
using Elibrium.BO;
using System.ComponentModel;
using System.Collections.ObjectModel;
using static ElibriumWPF.Util.Filter;
using static ElibriumWPF.Util.EmailHelper;

namespace ElibriumWPF.Views
{
    /// <summary>
    /// Interaction logic for PersonsPage.xaml
    /// </summary>
    public partial class PersonsPage : Page
    {
        private PersonsPageVM _vm;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        public PersonsPage()
        {
            this._vm = new PersonsPageVM();
            this.DataContext = this._vm;
            InitializeComponent();
            if (_vm.Persons.Count != 0)
            {
                lvPersons.ItemsSource = _vm.Persons;
                lvPersons.UpdateLayout();
            }
        }


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                // ... A null object.
                this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                this.Title = date.Value.ToShortDateString();
            }
        }

        private void btnRefreshPersons_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text != "")
            {
                lvPersons.ItemsSource = _vm.Persons;
            }
            lvPersons.UpdateLayout();
            e.Handled = true;
        }

        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            var persons = lvPersons.SelectedItems;
            if (persons.Count > 0)
            {
                foreach (PersonBO person in persons)
                {
                    if (person.Contacts.Count == 0 && person.Offers.Count == 0)
                    {
                        person.Delete();
                    }
                    else
                    {
                        MessageBox.Show("Customer has active offers or contacts, remove these before");
                    }
                }
                searchBox.Text = "";
                lvPersons.ItemsSource = _vm.Persons;
                lvPersons.UpdateLayout();
            }
            e.Handled = true;
        }

        private void add(int id, string firstName, string lastName, DateTime? db, int cId, int pId)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            try
            {
                dt = DateTime.Parse(db.ToString());
            }
            catch
            {

            }
            PersonBO bo = new PersonBO(id, firstName, lastName, dt, cId, pId);
            bo.AddOrUpdate();
        }


        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (!(firstName.Text.Equals("") || lastName.Text.Equals("") || date.Text.Equals("") || cBoxClients.Text.Equals("") || cBoxPositionTypes.SelectedItem == null))
            {
                DateTime dt = new DateTime(1900, 1, 1);
                try
                {
                    dt = DateTime.Parse(date.SelectedDate.ToString());
                }
                catch
                {

                }
                ClientBO cbo = cBoxClients.SelectedItem as ClientBO;
                PositionTypeBO pTo = cBoxPositionTypes.SelectedItem as PositionTypeBO;
                PersonBO bo = new PersonBO(0, firstName.Text, lastName.Text, dt, cbo._id, pTo.Id);
                if (bo.Age < 16)
                {
                    MessageBoxResult result = MessageBox.Show("The age of the person is less than 16, aborting add", "Warning", MessageBoxButton.OK);
                    return;
                }
                bo.AddOrUpdate();
                searchBox.Text = "";
                lvPersons.ItemsSource = _vm.Persons;
                lvPersons.UpdateLayout();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Add a valid Date, Name, Lastname, Client", "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void btnEditPerson_Click(object sender, RoutedEventArgs e)
        {
            if (lvPersons.SelectedItem != null)
            {
                PersonBO bo = lvPersons.SelectedItem as PersonBO;
                if (bo == null)
                {
                    bo = lvPersons.Items.CurrentItem as PersonBO;
                }

                if (cBoxClients.SelectedItem != null || cBoxPositionTypes.SelectedItem != null)
                {
                    ClientBO cbo = cBoxClients.SelectedItem as ClientBO;
                    add(bo.Id, firstName.Text, lastName.Text, date.SelectedDate, cbo._id, (cBoxPositionTypes.SelectedItem as PositionTypeBO).Id);
                }
                else
                {
                    ClientBO cbo = cBoxClients.SelectionBoxItem as ClientBO;
                    add(bo.Id, firstName.Text, lastName.Text, date.SelectedDate, cbo._id, (cBoxPositionTypes.SelectedItem as PositionTypeBO).Id);
                }
                lvPersons.ItemsSource = _vm.Persons;
                searchBox.Text = "";
                lvPersons.UpdateLayout();
                e.Handled = true;
            }
        }

        private void lvPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPersons.SelectedItem != null)
            {
                PersonBO a = lvPersons.SelectedItem as PersonBO;
                firstName.Text = a.FirstName;
                lastName.Text = a.LastName;
                date.Text = a.DBO;
                cBoxClients.Text = a.Client.Name.ToString();
                this._vm._contacts = a.Contacts;
                lvContacts.ItemsSource = _vm.Contacts;
                cBoxPositionTypes.Text = a.PositionType.Name.ToString();

            }
            e.Handled = true;
        }

        private void cBoxClients_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            ObservableCollection<ClientBO> data = _vm.Clients;

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;
            comboBox.DisplayMemberPath = "Name";
            comboBox.SelectedValuePath = "Id";

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void cbClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }


        private void TabItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            lvPersons.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("", System.ComponentModel.ListSortDirection.Ascending));
            e.Handled = true;
        }


        public void search(object sender, TextChangedEventArgs e)
        {

            if (searchBox.Text != "" && searchBox.Text.Length > 1)
            {
                string str = searchBox.Text;
                ObservableCollection<PersonBO> clts = new ObservableCollection<PersonBO>(_vm.Persons);
                int len = clts.Count;
                ObservableCollection<PersonBO> clts2 = new ObservableCollection<PersonBO>();

                for (int i = 0; i < len; i++)
                {
                    var item = clts[i];

                    if ((item.ToString().Contains(str)))
                    {
                        PersonBO a = item as PersonBO;
                        clts2.Add(a);
                    }
                }
                lvPersons.ItemsSource = clts2;
                lvPersons.UpdateLayout();
            }
            else
            {

                lvPersons.ItemsSource = _vm.Persons;
                lvPersons.UpdateLayout();
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


        private void cBoxContactTypes_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            ObservableCollection<ContactTypeBO> data = _vm.ContactTypes;

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;
            comboBox.DisplayMemberPath = "Name";
            comboBox.SelectedValuePath = "Id";

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void cBoxContactTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        private void btnAddContact_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.ContactTypes.Count > 0)
            {
                if (!contactValueBox.Text.Equals(""))
                {
                    PersonBO a = lvPersons.SelectedItem as PersonBO;
                    ContactTypeBO contactType = cBoxContactTypes.SelectedItem as ContactTypeBO;
                    if (a != null)
                    {
                        ContactBO cbo = new ContactBO(contactValueBox.Text, (lvPersons.SelectedItem as PersonBO).Id, (cBoxContactTypes.SelectedItem as ContactTypeBO).Id);
                        if (contactType.Name.Equals("Email"))
                        {
                            if (!IsValid(contactValueBox.Text))
                            {
                                MessageBoxResult result = MessageBox.Show("The email is invalid, aborting", "Warning", MessageBoxButton.OK);
                                return;
                            }
                        }
                        cbo.AddOrUpdate();
                        this._vm._contacts = a.Contacts;
                        lvContacts.ItemsSource = _vm.Contacts;
                        lvContacts.UpdateLayout();
                    }
                    else
                    {
                        MessageBox.Show("Select a Person first, to whom you want to add the contact", "A big fat warning", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Contact value can not be empty", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Add atleast one contact type first", "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void btnDeleteContact_Click(object sender, RoutedEventArgs e)
        {
            PersonBO person = lvPersons.SelectedItem as PersonBO;
            var contacts = lvContacts.SelectedItems;
            if (contacts.Count > 0)
            {
                foreach (ContactBO contact in contacts)
                {
                    contact.Delete();
                }
                if (person.Contacts != null)
                {
                    this._vm._contacts = person.Contacts;
                }
                else
                {
                    this._vm.Contacts = new ObservableCollection<ContactBO>();
                }

                lvContacts.ItemsSource = _vm.Contacts;
                lvContacts.UpdateLayout();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Select a contact to delete first", "A big fat warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void btnEditContact_Click(object sender, RoutedEventArgs e)
        {
            if (lvContacts.SelectedItem != null)
            {
                PersonBO cc = lvPersons.SelectedItem as PersonBO;
                ContactBO contact = new ContactBO((lvContacts.SelectedItem as ContactBO).Id, contactValueBox.Text, (lvPersons.SelectedItem as PersonBO).Id, ((cBoxContactTypes.SelectedItem) as ContactTypeBO).Id);
                if (contact.Id == 1 || cBoxContactTypes.SelectedItem.Equals("Email"))
                {
                    if (!IsValid(contactValueBox.Text))
                    {
                        MessageBoxResult result = MessageBox.Show("The email is invalid, aborting", "Warning", MessageBoxButton.OK);
                        return;
                    }
                }
                contact.AddOrUpdate();
                this._vm._contacts = cc.Contacts;
                lvContacts.ItemsSource = _vm.Contacts;
                lvContacts.UpdateLayout();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Select a Contact to edit first", "Warning", MessageBoxButton.OK);
            }
            e.Handled = true;
        }

        private void lvContacts_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if ((lvContacts.SelectedItem) != null)
            {
                contactValueBox.Text = (lvContacts.SelectedItem as ContactBO).Value;
                ContactTypeBO boo = (lvContacts.SelectedItem as ContactBO).ContactType;
                cBoxContactTypes.Text = boo.Name;
            }
            e.Handled = true;
        }

        private void cBoxPositionTypes_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            ObservableCollection<PositionTypeBO> data = _vm.PositionTypes;

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;
            comboBox.DisplayMemberPath = "Name";
            comboBox.SelectedValuePath = "Id";

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }
    }
}
