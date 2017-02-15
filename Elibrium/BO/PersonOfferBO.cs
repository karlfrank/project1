using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elibrium.Domain;
using Elibrium.Service;


namespace Elibrium.BO
{
    public class PersonOfferBO:BaseBO, IBO
    {
        private int _offerId { get; set; }
        private int _personId { get; set; }

        public string _status { get; set; }

        public PersonOfferBO( int oId, int cId, string Stat)
        {
            _offerId = oId;
            _personId = cId;
            _status = Stat;
        }

        public PersonOfferBO(int Idd, int oId, int cId, string Stat)
        {
            _id = Idd;
            _offerId = oId;
            _personId = cId;
            _status = Stat;
        }

        public PersonOfferBO(PersonOffer a)
        {
            _id = a.Id;
            _offerId = a.OfferId;
            _personId = a.PersonId;
            _status = a.Status;
        }

        public int OfferId
        {
            get
            {
                return _offerId;
            }
        }

        public int PersonId
        {
            get
            {
                return _personId;
            }
        }

        public string Status
        {
            get {
           return _status;
            }
        }

        public OfferBO Offer{
            get{
                return OfferService.GetOfferById(OfferId);
            }
        }

        public string Title
        {
            get
            {
                return Offer.Title;
            }
        }

        public PersonBO Person
        {
            get
            {
                return PersonService.GetPersonById(this.PersonId);
            }
        }


        public PersonOffer parseDomain()
        {
            return new PersonOffer()
            {
                Id = _id,
                OfferId = _offerId,
                PersonId = _personId,
                Status = _status,
            };
        }


        public void AddOrUpdate()
        {
            var personHasOffer = parseDomain();
            using (ElibriumEntities db = new ElibriumEntities())
            {
                if (_isNew)
                {
                    db.PersonOffer.Add(personHasOffer);
                }
                else
                {
                    PersonOffer temp = db.PersonOffer.Find(personHasOffer.Id);
                    temp.OfferId = personHasOffer.OfferId;
                    temp.PersonId = personHasOffer.PersonId;
                    temp.Status = personHasOffer.Status;
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            try {
            var personOffer = parseDomain();
            using (ElibriumEntities db = new ElibriumEntities())
            {
                PersonOffer temp = db.PersonOffer.Find(personOffer.Id);
                db.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            }
            catch
            {

            }
        }
    }
}
