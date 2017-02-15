using System.Collections.ObjectModel;
using Elibrium.BO;
using Elibrium.Service;

namespace ElibriumWPF.ViewModel
{
    class PersonsPageVM : BaseVM
    {
        public PersonsPageVM()
        {

        }

        private ObservableCollection<PersonBO> _persons
        {
            get { return PersonService.GetAllPersons(); }
            set
            {
                OnPropertyChanged("_persons");
            }
        }

        public ObservableCollection<PersonBO> Persons
        {
            get
            {
                return _persons;
            }
        }

        private ObservableCollection<ClientBO> _clients
        {
            get { return ClientService.GetAllClients(); }
            set
            {
                OnPropertyChanged("_clients");
            }
        }

        public ObservableCollection<ClientBO> Clients
        {
            get
            {
                return _clients;
            }
        }

        private ObservableCollection<ContactTypeBO> _contactTypes = ContactTypeService.GetAllContactTypes();
        public ObservableCollection<ContactTypeBO> ContactTypes
        {
            get
            {
                return _contactTypes;
            }
            set
            {
                OnPropertyChanged("_contactTypes");
            }
        }

        private ObservableCollection<PositionTypeBO> _positionTypes = PositionTypeService.GetAllPositionTypes();
        public ObservableCollection<PositionTypeBO> PositionTypes
        {
            get
            {
                return _positionTypes;
            }
            set
            {
                OnPropertyChanged("_positionTypes");
            }
        }

        public ObservableCollection<ContactBO> _contacts;
        public ObservableCollection<ContactBO> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                OnPropertyChanged("_contacts");
            }
        }
    }
}
