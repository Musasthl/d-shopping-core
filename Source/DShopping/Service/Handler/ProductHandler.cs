using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTO;
using DataTier.Entities;
using DataTier.DAO;

namespace Service.Handler
{
    public class ProductHandler
    {
        public List<ProductDto> GetProductsByCategoryId(int categoryId)
        {
            var listProduct = new List<ProductDto>();

            var list = ProductDAO.getAllProductByCategory(categoryId);

            return null;
        }

        public static List<ProductOverviewDto> getNewestProduct()
        {
            List<Products> newestProduct = ProductDAO.getNewestProduct(CONST.PRODUCT.NO_NEWEST).ToList();

            return Common.convertOverview(newestProduct);
        }

        
    }
}
