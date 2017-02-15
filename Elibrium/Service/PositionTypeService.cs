using System;
using System.Collections.Generic;
using System.Linq;
using Elibrium.BO;
using Elibrium.Domain;
using System.Collections.ObjectModel;


namespace Elibrium.Service
{
    public class PositionTypeService
    {

        public static ObservableCollection<PositionTypeBO> GetAllPositionTypes()
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var positionTypes = db.PositionType.ToList();
                ObservableCollection<PositionTypeBO> cts = new ObservableCollection<PositionTypeBO>();
                foreach (var positionType in positionTypes)
                {
                    PositionTypeBO pt = new PositionTypeBO(positionType);
                    cts.Add(pt);
                }
                return cts;
            }
        }

        public static bool PositionTypeInUse(PositionType a)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                var Positions = db.Person.Where(x => x.PositionTypeId == a.Id);
                if (Positions.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static PositionType GetPositionType(int ptId)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                PositionType positionType = db.PositionType.Where(x => x.Id == ptId).Single();
                return positionType;
            }
        }

    }
}
