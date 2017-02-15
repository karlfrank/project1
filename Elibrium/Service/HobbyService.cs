using System;
using System.Collections.Generic;
using System.Linq;
using Elibrium.BO;
using Elibrium.Domain;
using System.Collections.ObjectModel;

namespace Elibrium.Service
{
    class HobbyService
    {
        public static ObservableCollection<HobbyBO> GetAllHobbies(PersonBO pb)
        {
            return new ObservableCollection<HobbyBO>();
        }


        public static ObservableCollection<HobbyBO> GetHobbiesByPerson(PersonBO pb)
        {
            return new ObservableCollection<HobbyBO>();
        }


        public static List<HobbyBO> GetHobbyById(int id)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                List<HobbyBO> hbos = new List<HobbyBO>();
                hbos.Add(new HobbyBO(db.Hobby.Find(id)));
                return hbos;
            }
        }

    }
}
