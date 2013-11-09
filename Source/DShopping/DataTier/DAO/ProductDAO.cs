using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
{
    public class ProductDAO : DAO
    {
        public static Products getProductById(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.Get<Products>(id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Products getProductByName(string name)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Product = session.QueryOver<Products>()
                                    .Where(p => p.Name == name
                                              && p.Status.Id == "Active")
                        .List();

                    return Product.ElementAt(0);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Products getProductByCode(string code)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Product = session.QueryOver<Products>()
                                    .Where(p => p.Code == code
                                              && p.Status.Id == "Active")
                        .List();

                    return Product.ElementAt(0);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IList<Products> getAllProduct()
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Product = session.QueryOver<Products>().List()
                                     .Where(p => p.Status.Id == "Active")
                                     .ToList();

                    return Product;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IList<Products> getAllProductByCategory(int categoryId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Product = session.QueryOver<Products>()
                                     .Where(p => p.Category.CategoryId == categoryId
                                                && p.Status.Id == "Active")
                        .List();

                    return Product.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IList<Products> getHotProduct()
        {

            return null;

        }

        public static IList<Products> getDiscountProduct()
        {
            return null;
        }

        public static IList<Products> getNewestProduct(int noOfProduct)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Product = session.QueryOver<Products>()
                        
                        .Where(p => p.Status.Id == "Active")
                        .OrderBy(p => p.CreatedDate).Desc
                        .Take(noOfProduct)
                        .List();

                    return Product;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
