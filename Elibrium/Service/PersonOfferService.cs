using System;
using System.Collections.Generic;
using System.Linq;
using Elibrium.BO;
using Elibrium.Domain;
using System.Collections.ObjectModel;

namespace Elibrium.Service
{
    public class PersonOfferService
    {
        public static ObservableCollection<PersonOfferBO> GetPersonOffers(Person a)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var offers = db.PersonOffer.Where(x => x.PersonId == a.Id);
                ObservableCollection<PersonOfferBO> ofrs = new ObservableCollection<PersonOfferBO>();
                foreach (var o in offers)
                {
                    ofrs.Add(new PersonOfferBO(o));
                }
                return ofrs;
            }
        }


        public static ObservableCollection<PersonOfferBO> GetPersonOffersByOfferId(int id)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var offers = db.PersonOffer.Where(x => x.OfferId == id).ToList();
                ObservableCollection<PersonOfferBO> a = new ObservableCollection<PersonOfferBO>();
                foreach (var o in offers)
                {
                    a.Add(new PersonOfferBO(o));
                }
                return a;
            }
        }

        public static ObservableCollection<PersonOfferBO> GetPersonOffersForClient(int id)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                ObservableCollection<PersonBO> persons  = PersonService.GetPersonsByClientId(id);
                ObservableCollection<PersonOfferBO> offer = new ObservableCollection<PersonOfferBO>();
                foreach(PersonBO person in persons)
                {
                    ObservableCollection<PersonOfferBO> ofrs = GetPersonOffers((person).parseDomain());
                    foreach(PersonOfferBO ofr in ofrs)
                    {
                        offer.Add(ofr);
                    }
                }
                return offer;
            }
        }
    }
}
