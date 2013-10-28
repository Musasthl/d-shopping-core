using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
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
                        
                        return false;
                    }
                }
            }
        }
        public static void Update(User User)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(User);
                    transaction.Commit();
                }
            }
        }

        public static void Remove(User User)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(User);
                    transaction.Commit();
                }
            }
        }

    }
}
