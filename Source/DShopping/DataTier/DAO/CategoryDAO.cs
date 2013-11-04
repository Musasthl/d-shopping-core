using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
{
    public class CategoryDAO : DAO
    {

        public static IList<Categories> getAllActiveCategory()
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Category = session.QueryOver<Categories>()
                        .Where(p => p.Status.Id == "Active" )
                        .OrderBy(p => p.Position).Asc
                        .List();
                    return Category.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
