using System;
using Elibrium.Domain;

namespace Elibrium.BO
{
    public class HobbyBO : BaseBO, IBO
    {
        public string _name { get; set; }
        public int _personId { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int PersonId
        {
            get
            {
                return _personId;
            }
        }

        public HobbyBO(Hobby h)
        {
            _name = h.Name;
            _personId = h.PersonId;
        }
        public Hobby parseDomain()
        {
            return new Hobby()
            {
                Id = _id,
                Name = _name,
                PersonId = _personId,
            };
        }

        public void AddOrUpdate()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
