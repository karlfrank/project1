using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elibrium.Domain;
using Elibrium.Service;
using System.Collections.ObjectModel;

namespace Elibrium.BO
{
    public class PersonBO : BaseBO, IBO
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public DateTime _dbo { get; set; }
        public int _clientId { get; set; }

        public int _positionTypeId { get; set; }

        public string FirstName
        {
            get
            {
                return this._firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this._lastName;
            }
        }

        public string DBO
        {
            get
            {
                return this._dbo.ToShortDateString();
            }
        }

        public int ClientId
        {
            get
            {
                return this._clientId;
            }
        }

        public int PositionTypeId
        {
            get
            {
                return this._positionTypeId;
            }
        }

        public PositionTypeBO PositionType
        {
            get
            {
                return new PositionTypeBO(PositionTypeService.GetPositionType(PositionTypeId));
            }
        }

        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Now;
                int age = DateTime.Now.Year -_dbo.Year;
                if (_dbo > today.AddYears(-1*age))
                {
                    age--;
                }
                return age;
            }
        }

        public ObservableCollection<PersonOfferBO> Offers
        {
            get
            {
                return PersonOfferService.GetPersonOffers(this.parseDomain());
            }
        }

        public ContactBO Email
        {
            get
            {
                return ContactService.GetSpecificContactForPerson(1,this.parseDomain());
            }
        }

        public PersonBO(int idcode, string first, string last, DateTime dateOfBirth, int ClientsId,int PositionTypesId)
        {
            _id = idcode;
            _firstName = first;
            _lastName = last;
            _dbo = dateOfBirth;
            _clientId = ClientsId;
            _positionTypeId = PositionTypesId;
        }

        public PersonBO(Person person)
        {
            _id = person.Id;
            _firstName = person.FirstName;
            _lastName = person.LastName;
            _dbo = person.DBO;
            _clientId = person.ClientId;
            _positionTypeId = person.PositionTypeId;
        }

        public Person parseDomain()
        {
            return new Person()
            {
                Id = _id,
                FirstName = _firstName,
                LastName = _lastName,
                DBO = _dbo,
                ClientId = _clientId,
                PositionTypeId = _positionTypeId
            };
        }

        public void AddOrUpdate()
        {
            var Person = parseDomain();
            using (ElibriumEntities db = new ElibriumEntities())
            {
                if (_isNew)
                {
                    db.Person.Add(Person);
                }
                else
                {
                    Person temp = db.Person.Find(Person.Id);
                    temp.FirstName = Person.FirstName;
                    temp.LastName = Person.LastName;
                    temp.DBO = Person.DBO;
                    temp.ClientId = Person.ClientId;
                    temp.PositionTypeId = Person.PositionTypeId;
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            try {
            var client = parseDomain();
            ElibriumEntities db = new ElibriumEntities();
            {
                Person temp = db.Person.Find(client.Id);
                db.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                List<Contact> temp2 = db.Contact.Where(i => Id == temp.Id).ToList();
                foreach (Contact item in temp2)
                {

                }
                db.SaveChanges();
            }
            }catch
            {

            }
        }

        override
        public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_id + " ").Append(_firstName).Append(" " + _lastName).Append(" " + _dbo.ToShortDateString()).Append(" " + _clientId);
            return sb.ToString();
        }

        public ObservableCollection<ContactBO> Contacts
        {
            get
            {
                return ContactService.GetPersonContacts(this.parseDomain());
                }
            }
        public ClientBO Client
        {
            get
            {
                return new ClientBO(ClientService.GetClientById(ClientId));
            }
        }

        public ObservableCollection<HobbyBO> Hobbies
        {
            get
            {
                return HobbyService.GetHobbiesByPerson(this);
            }
        }
    }
    }
