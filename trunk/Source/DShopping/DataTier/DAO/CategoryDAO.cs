using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.Entities;
using NHibernate;
using NHibernate.Linq;

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

        public static Categories getCategoryByName(string name)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Categories = session.QueryOver<Categories>()
                                    .Where(p => p.Name == name
                                              && p.Status.Id == "Active")
                        .List();

                    return Categories.ElementAt(0);
                }
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

        public static List<Categories> GetHotCategories(int noOfCategories, int parentCategoryId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var test = session.Query<Categories>().ToList();
                    var Category = session.Query<Categories>()
                        .Where(p => p.Child.Any(pr => pr.Parent.CategoryId == parentCategoryId))
                        .OrderBy(p => p.Position)
                        .Take(noOfCategories);
                    
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
