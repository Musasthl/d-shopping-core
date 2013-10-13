using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.DTO;
using NHibernate;
using NHibernate.Criterion;

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
                        COM.Logger.getInstance().log(e.ToString());
                        return false;
                    }
                }
            }
        }
        public static bool Update(Category Category)
        {
            {
                try
                {
                    using (ISession session = NHibernateHelper.OpenSession())
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(Category);
                        transaction.Commit();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    COM.Logger.getInstance().log(e.ToString());
                    return false;
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
        public static Category GetCategoryById(int CategoryId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Category>(CategoryId);
        }
        public static Category GetCategoryByName(String CategoryName)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var Category = session
                    .CreateCriteria(typeof(Category))
                    .Add(Restrictions.Eq("Name", CategoryName))
                    .UniqueResult<Category>();
                return Category;
            }
        }
        public static IList<Category> GetAll()
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Category = session.QueryOver<Category>()
                        .List();
                    return Category.ToList();
                }
            }
            catch (Exception ex)
            {
                COM.Logger.getInstance().log(ex.ToString());
                return null;
            }
        }
    }
}
