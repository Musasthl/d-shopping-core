using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
{
    public class StatusDAO
    {
        public static Status getStatusById(String id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.Get<Status>(id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
