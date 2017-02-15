using System;
using System.Collections.Generic;
using System.Linq;
using Elibrium.BO;
using Elibrium.Domain;
using System.Collections.ObjectModel;

namespace Elibrium.Service
{
    public class ClientService
    {

        public static ObservableCollection<ClientBO> GetAllClients()
        {
            List<ClientBO> clts = new List<ClientBO>();
            var clients = new List<Client>();

            using (ElibriumEntities db = new ElibriumEntities())
            {
                if (db.Client.Count() > 0)
                {
                    clients = db.Client.ToList();
                    foreach (var client in clients)
                    {
                        ClientBO clt = new ClientBO(client);
                        clts.Add(clt);
                    }
                }
            }
            return new ObservableCollection<ClientBO>(clts);
        }

        public static Client GetClientById(int id)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                return db.Client.Find(id);
            }
        }

        public static void DeleteClientById(int id)
        {
            using (ElibriumEntities db = new ElibriumEntities())
            {
                Client a = db.Client.Find(id);
                db.Client.Remove(a);
            }
        }

    }
}
