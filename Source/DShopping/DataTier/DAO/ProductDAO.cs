using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.Entities;

namespace DataTier.DAO
{
    public class ProductDAO:DAO
    {
        public static Products getProductById(int id)
        {
            return null;
        }

        public static Products getProductByName(string name)
        {
            return null;
        }

        public static Products getProductByCode(string code)
        {
            return null;
        }

        public static IList<Products> getAllProduct()
        {
            return null;
        }

        public static IList<Products> getAllProductByCategory(int categoryId)
        {
            return null;
        }

        public static IList<Products> getHotProduct()
        {
            return null;
        }

        public static IList<Products> getDiscountProduct()
        {
            return null;
        }
    }
}
