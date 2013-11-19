using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
{
    public class UserDAO : DAO
    {
        public static Users getUserById(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.Get<Users>(id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IList<Users> getAllActiveUser()
        {
            return null;
        }

        public static Users getUserByName(String username)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var User = session.QueryOver<Users>()
                                    .Where(p => p.Username == username
                                              && p.Status.Id == "Active")
                        .List();

                    return User.ElementAt(0);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
