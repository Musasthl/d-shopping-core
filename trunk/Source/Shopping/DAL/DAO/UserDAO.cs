using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.DTO;
using NHibernate;
using COM;

namespace DAL.DAO
{
    public class UserDAO
    {
        public static bool Add(User user)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(user);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Logger.getInstance().log(e.ToString());
                        return false;
                    }
                }
            }
        }
    }
}
