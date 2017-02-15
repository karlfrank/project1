using System.Collections.ObjectModel;
using Elibrium.BO;
using Elibrium.Service;

namespace ElibriumWPF.ViewModel
{
    class ContactTypePageVM : BaseVM, IContactTypePageVM
    {
        public ContactTypePageVM()
        {

        }

        private ObservableCollection<ContactTypeBO> _contactTypes
        {
            get
            {
                return ContactTypeService.GetAllContactTypes();
            }
            set
            {
                OnPropertyChanged("_contactTypes");
            }
        }

        public ObservableCollection<ContactTypeBO> ContactTypes
        {
            get
            {
                return _contactTypes;
            }
        }

        public void GetContactTypes()
        {
            _contactTypes = ContactTypeService.GetAllContactTypes();
        }

        public bool ContactTypeInUse(ContactTypeBO a)
        {
            return ContactTypeService.ContactTypeInUse(a.parseDomain());
        }

    }
}
