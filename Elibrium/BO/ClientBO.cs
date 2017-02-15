using System;
using System.Text;
using Elibrium.Domain;
using Elibrium.Service;
using System.Collections.ObjectModel;

namespace Elibrium.BO
{
    public class ClientBO :BaseBO, IBO
    {
        public string _name { get; set; }
        public string _businessNo { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string BusinessNo
        {
            get
            {
                return _businessNo;
            }
        }


        public ClientBO(int id, string name, string businessNo)
        {
            _id = id;
            _name = name;
            _businessNo = businessNo;
        }
        public ClientBO(Client client)
        {
            _id = client.Id;
            _name = client.Name;
            _businessNo = client.BusinessNo;
        }

        public Client parseDomain()
        {
            return new Client()
            {
                Id = _id,
                Name = _name,
                BusinessNo = _businessNo,
            };
        }

        public void AddOrUpdate()
        {
            var client = parseDomain();
            using (ElibriumEntities db = new ElibriumEntities())
            {
                if (_isNew)
                {
                    db.Client.Add(client);
                }
                else
                {
                    Client temp = db.Client.Find(client.Id);
                    temp.Name = client.Name;
                    temp.BusinessNo = client.BusinessNo;
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
                Client temp = db.Client.Find(client.Id);
                db.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            }
            catch { }
        }

        override
        public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_id + " ").Append(_name).Append(" " + _businessNo);
            return sb.ToString();
        }

        public ObservableCollection<PersonBO> Persons{
            get{
               return PersonService.GetPersonsByClientId(Id);
            }
        }
    }
}
