using System.Collections.ObjectModel;
using Elibrium.BO;
using Elibrium.Service;
using static ElibriumWPF.Util.EmailHelper;

namespace ElibriumWPF.ViewModel
{
    public class ClientsPageVM : BaseVM
    {
        public ClientsPageVM()
        {

        }

        public ObservableCollection<ClientBO> Clients
        {
            get
            {
                return ClientService.GetAllClients();
            }
        }

        public ObservableCollection<PersonBO> BirthDays
        {
            get
            {
                return PersonService.GetPersonsWithBirthdays();
            }
        }

        private ObservableCollection<ContactTypeBO> _contactTypes = ContactTypeService.GetAllContactTypes();
        public ObservableCollection<ContactTypeBO> ContactTypes
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

        public ObservableCollection<PersonBO> _persons;
        public ObservableCollection<PersonBO> Persons
        {
            get
            {
                return _persons;
            }
            set
            {
                OnPropertyChanged("_persons");
            }
        }



        public ObservableCollection<PersonBO> AllPersons
        {
            get
            {
                return PersonService.GetAllPersons();
            }
        }

        private ObservableCollection<PersonBO> _personswithbirthday = PersonService.GetPersonsWithBirthdays();
        public ObservableCollection<PersonBO> PersonsWithBirthday
        {
            get
            {
                return _personswithbirthday;
            }
            set
            {
                OnPropertyChanged("_personswithbirthday");
            }
        }

        public void SendBirthDayMails()
        {
            foreach (PersonBO person in PersonsWithBirthday)
            {
                if (person.Email != null && IsValid(person.Email.Value))
                {
                    EmailService.SendBirthdayMessage(person);
                }
            }
        }

        public ObservableCollection<PersonOfferBO> GetClientOffers(int id)
        {
            return PersonOfferService.GetPersonOffersForClient(id);
        }
    }
}
