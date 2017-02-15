using Elibrium.Service;
using Elibrium.Domain;

namespace Elibrium.BO
{
    public class ContactTypeBO : BaseTypeBO, IBO
    {
        public ContactTypeBO(string name)
        {
            _name = name;
        }
        public ContactTypeBO(int ctId, string ctName)
        {
            _id = ctId;
            _name = ctName;
        }
        public ContactTypeBO(ContactType ct)
        {
            _id = ct.Id;
            _name = ct.Name;
        }
        public ContactType parseDomain()
        {
            return new ContactType()
            {
                Id = _id,
                Name = _name,
            };
        }

        public void AddOrUpdate()
        {
            var contactType = parseDomain();
            using (ElibriumEntities db = new ElibriumEntities())
            {
                if (_isNew)
                {
                    db.ContactType.Add(contactType);
                }
                else
                {
                    ContactType temp = db.ContactType.Find(contactType.Id);
                    temp.Name = contactType.Name;
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            try {
            ContactType contactType = parseDomain();
            ElibriumEntities db = new ElibriumEntities();
            {
                ContactType temp = db.ContactType.Find(contactType.Id);
                db.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            }
            catch
            {

            }
        }

        public bool InUse
        {
            get {
                return ContactTypeService.ContactTypeInUse(this.parseDomain());
                }
        }

        public static void AddEmail()
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                ContactType temp = db.ContactType.Find(1);
                if (temp != null)
                {
                    temp.Name = "Email";
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    //run the script here
                }
                db.SaveChanges();
            }
        }
    }
}
