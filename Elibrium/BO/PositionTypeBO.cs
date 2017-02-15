using Elibrium.Domain;
using Elibrium.Service;

namespace Elibrium.BO
{
    public class PositionTypeBO : BaseTypeBO, IBO
    {
        public PositionTypeBO(string name)
        {
            _name = name;
        }
        public PositionTypeBO(int ctId, string ctName)
        {
            _id = ctId;
            _name = ctName;
        }
        public PositionTypeBO(PositionType ct)
        {
            _id = ct.Id;
            _name = ct.Name;
        }
        public PositionType parseDomain()
        {
            return new PositionType()
            {
                Id = _id,
                Name = _name,
            };
        }

        public void AddOrUpdate()
        {
            var PositionType = parseDomain();
            using (ElibriumEntities db = new ElibriumEntities())
            {
                if (_isNew)
                {
                    db.PositionType.Add(PositionType);
                }
                else
                {
                    PositionType temp = db.PositionType.Find(PositionType.Id);
                    temp.Name = PositionType.Name;
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            PositionType PositionType = parseDomain();
            ElibriumEntities db = new ElibriumEntities();
            {
                try {
                PositionType temp = db.PositionType.Find(PositionType.Id);
                db.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                }
                catch
                {

                }
                }
        }

        public bool InUse
        {
            get
            {
                return PositionTypeService.PositionTypeInUse(this.parseDomain());
            }
        }

    }
}
