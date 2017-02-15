using System;
using System.Collections.Generic;
using System.Linq;
using Elibrium.BO;
using Elibrium.Domain;
using System.Collections.ObjectModel;


namespace Elibrium.Service
{
    public class PersonService
    {
        public static ObservableCollection<PersonBO> GetAllPersons()
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                ObservableCollection<PersonBO> ccs = new ObservableCollection<PersonBO>();
                if (db.Person.Count() > 0)
                {
                    var Persons = db.Person.ToList();
                    foreach (var clc in Persons)
                    {
                        PersonBO cc = new PersonBO(clc);
                        ccs.Add(cc);
                    }
                }
                return ccs;
            }
        }

        public static ObservableCollection<PersonBO> GetPersonsWithBirthdays()
        {
                     using (ElibriumEntities db = new ElibriumEntities())
            {
                ObservableCollection<PersonBO> ccs = new ObservableCollection<PersonBO>();
                if (db.Person.Count() > 0)
                {
                    var Persons = db.Person.Where(x => x.DBO.Day == DateTime.Now.Day && x.DBO.Month == DateTime.Now.Month).ToList();
                    foreach (var clc in Persons)
                    {
                        PersonBO cc = new PersonBO(clc);
                        ccs.Add(cc);
                    }
                }
                return ccs;
            }
        }

        public static PersonBO GetPersonById(int id)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                List<PersonBO> cclts = new List<PersonBO>();
                cclts.Add(new PersonBO(db.Person.Find(id)));
                return cclts.First();
            }
        }

        public static ObservableCollection<PersonBO> GetPersonsByClientId(int id)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var Persons = db.Person.Where(x => x.ClientId == id);
                ObservableCollection<PersonBO> ccs = new ObservableCollection<PersonBO>();
                foreach (var clc in Persons)
                {
                    PersonBO cc = new PersonBO(clc);
                    ccs.Add(cc);
                }
                return ccs;
            }
        }
    }
}
