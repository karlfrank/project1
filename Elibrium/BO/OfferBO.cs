using System;
using Elibrium.Domain;
using Elibrium.Service;
using System.Collections.ObjectModel;

namespace Elibrium.BO
{
    public class OfferBO : BaseBO , IBO
    {
        public string _title { get; set; }
        public string _description { get; set; }
        public DateTime _dateFrom { get; set; }
        public DateTime _dateTo { get; set; }

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public DateTime DateFrom
        {
            get
            {
                return _dateFrom;
            }
        }

        public DateTime DateTo
        {
            get
            {
                return _dateTo;
            }
        }

        public OfferBO(int id, string title, string desc, DateTime from, DateTime to)
        {
            _id = id;
            _title = title;
            _description = desc;
            _dateFrom = from;
            _dateTo = to;
        }

        public OfferBO(Offer o)
        {
            _id = o.Id;
            _title = o.Title;
            _description = o.Description;
            _dateTo = o.DateTo;
            _dateFrom = o.DateFrom;
        }
        private Offer parseDomain()
        {
            return new Offer()
            {
                Id = _id,
                Title = _title,
                Description = _description,
                DateFrom = _dateFrom,
                DateTo = _dateTo
            };
        }

        public void AddOrUpdate()
        {
            var Offer = parseDomain();
            using (ElibriumEntities db = new ElibriumEntities())
            {
                if (_isNew)
                {
                    db.Offer.Add(Offer);
                }
                else
                {
                    Offer temp = db.Offer.Find(Offer.Id);
                    temp.Title = Offer.Title;
                    temp.Description = Offer.Description;
                    temp.DateFrom = Offer.DateFrom;
                    temp.DateTo = Offer.DateTo;
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            try {
            var offer = parseDomain();
            ElibriumEntities db = new ElibriumEntities();
            {
                Offer temp = db.Offer.Find(offer.Id);
                db.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            }
            catch { }
        }

        public ObservableCollection<PersonOfferBO> PersonOffers{
            get{
                return PersonOfferService.GetPersonOffersByOfferId(Id);
            }
        }

        public string toString()
        {
            return (Title + " " + Description);
        }
    }
}
