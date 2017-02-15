using System;
using System.Collections.Generic;
using System.Linq;
using Elibrium.BO;
using Elibrium.Domain;
using System.Collections.ObjectModel;

namespace Elibrium.Service
{
    public class ContactTypeService
    {
        public static ObservableCollection<ContactTypeBO> GetAllContactTypes()
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var contactTypes = db.ContactType.ToList();
                ObservableCollection<ContactTypeBO> cts = new ObservableCollection<ContactTypeBO>();
                foreach (var contactType in contactTypes)
                {
                    ContactTypeBO ct = new ContactTypeBO(contactType);
                    cts.Add(ct);
                }
                return cts;
            }
        }


        public static bool ContactTypeInUse(ContactType a)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var Contacts = db.Contact.Where(x => x.ContactTypeId == a.Id);
                if (Contacts.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public static ContactType GetContactType(int ctId)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                ContactType contactType = db.ContactType.Where(x => x.Id == ctId).Single();
                return contactType;
            }
        }
    }
}
