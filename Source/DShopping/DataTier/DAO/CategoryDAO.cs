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
        public static Categories getCategoryById(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.Get<Categories>(id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

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

        public static IList<Categories> getAllActiveCategoryByParent(int ParentId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var CategoryRel = session.QueryOver<CategoryRelations>()
                        .Where(p => p.Parent.CategoryId == ParentId
                        )
                        .List();
                    IList<Categories> Categories = new List<Categories>();
                    foreach (CategoryRelations _catRel in CategoryRel)
                        Categories.Add(getCategoryById(_catRel.Child.CategoryId));
                    return Categories;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
