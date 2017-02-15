using System;
using System.Collections.Generic;
using System.Linq;
using Elibrium.BO;
using Elibrium.Domain;
using System.Collections.ObjectModel;

namespace Elibrium.Service
{
    class EmailTemplateService
    {
        public static ObservableCollection<EmailTemplateBO> GetAllEmailTemplates()
        {
            ObservableCollection<EmailTemplateBO> ets = new ObservableCollection<EmailTemplateBO>();
            var emailTemplates = new List<EmailTemplate>();

            using (ElibriumEntities db = new ElibriumEntities())
            {
                if (db.Client.Count() > 0)
                {
                    emailTemplates = db.EmailTemplate.ToList();
                    foreach (var et in emailTemplates)
                    {
                        EmailTemplateBO clt = new EmailTemplateBO(et);
                        ets.Add(clt);
                    }
                }
            }
            return ets;
        }
    }
}
