using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.DTO;

namespace DAL.DAO
{
    public class RoleDAO
    {
        public static Role getRoleById(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
                return session.Get<Role>(id);
        }
    }
}
