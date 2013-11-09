using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
{
    public class RoleDAO:DAO
    {
        public static Roles getRoleById(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.Get<Roles>(id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
