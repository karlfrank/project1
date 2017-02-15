using System;
using System.Collections.Generic;
using System.Linq;
using Elibrium.BO;
using Elibrium.Domain;
using System.Collections.ObjectModel;

namespace Elibrium.Service
{

    public class ContactService
    {

        public static Contact GetContactById(int ctId)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                Contact contact = db.Contact.Where(x => x.Id == ctId).Single();
                return contact;
            }
        }

        public static ObservableCollection<ContactBO> GetPersonContacts(Person a)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var Contacts = db.Contact.Where(x => x.PersonId == a.Id);
                ObservableCollection<ContactBO> ccs = new ObservableCollection<ContactBO>();
                if (Contacts.Count() > 0)
                {
                    foreach (var clc in Contacts)
                    {
                        ContactBO cc = new ContactBO(clc);
                        ccs.Add(cc);
                    }
                }
                return ccs;
            }
        }

        public static ContactBO GetSpecificContactForPerson(int contactType,Person a)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var Contacts = db.Contact.Where(x => x.ContactTypeId==contactType && x.PersonId == a.Id);
                ObservableCollection<ContactBO> ccs = new ObservableCollection<ContactBO>();
                Contact contact = Contacts.FirstOrDefault();
                if (contact != null)
                {
                    return new ContactBO(contact);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
