using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
{
    public class ProductDetailDAO
    {
        public static IList<ProductDetails> getAllProductDetailByTypeId(int productId, string typeId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Product = session.QueryOver<ProductDetails>()
                                     .Where(p => p.ProductTypeId.Id == typeId
                                                && p.Product.Id == productId
                                                && p.Status.Id == "Active")
                                                .OrderBy(p => p.CreatedDate).Desc
                        .List();

                    return Product.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
