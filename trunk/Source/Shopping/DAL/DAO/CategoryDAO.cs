using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.DTO;
using NHibernate;

namespace DAL.DAO
{
    public class CategoryDAO
    {
        public static bool Add(Category Category)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(Category);
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
        public static void Update(Category Category)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(Category);
                    transaction.Commit();
                }
            }
        }

        public static void Remove(Category Category)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(Category);
                    transaction.Commit();
                }
            }
        }

    }
}
