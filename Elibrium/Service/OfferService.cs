using System;
using System.Collections.Generic;
using System.Linq;
using Elibrium.BO;
using Elibrium.Domain;
using System.Collections.ObjectModel;

namespace Elibrium.Service
{
    public class OfferService
    {

        public static ObservableCollection<OfferBO> GetAllOffers()
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var offers = db.Offer.ToList();
                ObservableCollection<OfferBO> ofrs = new ObservableCollection<OfferBO>();
                foreach (var o in offers)
                {
                    OfferBO cc = new OfferBO(o);
                    ofrs.Add(cc);
                }
                return ofrs;
            }
        }

        public static OfferBO GetOfferById(int id)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                List<OfferBO> offers = new List<OfferBO>();
                offers.Add(new OfferBO(db.Offer.Find(id)));
                return offers.First();
            }
        }

    }
}
