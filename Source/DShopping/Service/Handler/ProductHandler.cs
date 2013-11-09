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
        public List<ProductDto> GetProdcutsByCategoryId(int categoryId)
        {
            var listProduct = new List<ProductDto>();

            var list = ProductDAO.getAllProductByCategory(categoryId);

            return null;
        }
    }
}
