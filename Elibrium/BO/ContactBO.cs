using Elibrium.Service;
using Elibrium.Domain;


namespace Elibrium.BO
{
    public class ContactBO : BaseBO, IBO
    {
        public string _value { get; set; }
        public int _personId { get; set; }
        public int _contactTypeId { get; set; }

        public ContactBO(string val, int oid, int ctid)
        {
            this._value = val;
            this._personId = oid;
            this._contactTypeId = ctid;
        }

        public ContactBO(int idd , string val, int oid, int ctid)
        {
            this._id = idd;
            this._value = val;
            this._personId = oid;
            this._contactTypeId = ctid;
        }

        public ContactBO(Contact c)
        {
            _id = c.Id;
            _value = c.Value;
            _personId = c.PersonId;
            _contactTypeId = c.ContactTypeId;
        }

        public string Value{
            get
            {
                return this._value;
            }
        }

        public int OwnerId{
            get
            {
                return this._personId;
            }
        }


        public ContactTypeBO ContactType
        {
            get
            {
                return new ContactTypeBO(ContactTypeService.GetContactType(this._contactTypeId));
            }
        }

        public Contact parseDomain()
        {
            return new Contact()
            {
                Id = _id,
                Value = _value,
                PersonId = _personId,
                ContactTypeId = _contactTypeId
            };
        }

        public void AddOrUpdate()
        {
            var contact = parseDomain();
            using (ElibriumEntities db = new ElibriumEntities())
            {
                if (_isNew)
                {
                    db.Contact.Add(contact);
                }
                else
                {
                    Contact temp = db.Contact.Find(contact.Id);
                    temp.Value = contact.Value;
                    temp.PersonId = contact.PersonId;
                    temp.ContactTypeId = contact.ContactTypeId;
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            try { 
            var contact = parseDomain();
            ElibriumEntities db = new ElibriumEntities();
            {
                Contact temp = db.Contact.Find(contact.Id);
                db.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            }
            catch { }
        }
    }
}
