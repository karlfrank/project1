using System.Collections.ObjectModel;
using Elibrium.BO;
using Elibrium.Service;
using System.Collections.Generic;


namespace ElibriumWPF.ViewModel
{
    class OffersPageVM : BaseVM
    {

        public OffersPageVM()
        {

        }

        private ObservableCollection<OfferBO> _offers
        {
            get
            {
                return OfferService.GetAllOffers();
            }
            set
            {
                OnPropertyChanged("_offers");
            }
        }

        public ObservableCollection<OfferBO> Offers
        {
            get
            {
                return _offers;
            }
        }

        private ObservableCollection<PersonBO> _customers
        {
            get
            {
                return PersonService.GetAllPersons();
            }
            set
            {
                OnPropertyChanged("_customers");
            }
        }

        public ObservableCollection<PersonBO> Customers
        {
            get
            {
                return _customers;
            }
        }

        private List<string> _statuses = new List<string> { "Disabled", "Active", "Accepted", "Ended" };
        public List<string> Statuses
        {
            get
            {
                return _statuses;
            }
        }

        public bool SendOffer(PersonOfferBO pbo)
        {
            try
            {
                return EmailService.SendOffer(pbo.Person, pbo.Offer.Description, pbo.Offer.Title);
            }
            catch
            {
                return false;
            }
        }
    }
}
