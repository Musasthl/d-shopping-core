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

        public static List<ProductDto> getNewestProduct()
        {
            List<Products> newestProduct = ProductDAO.getNewestProduct(CONST.PRODUCT.NO_NEWEST).ToList();

            return convert(newestProduct);
        }

        public static List<ProductDto> convert(List<Products> listProducts)
        {
            List<ProductDto> newListProdDto = new List<ProductDto>();
            foreach (Products prods in listProducts)
            {
                newListProdDto.Add(convert(prods));

            }
            return newListProdDto;
        }

        public static ProductDto convert(Products products)
        {
            ProductDto prodDto = new ProductDto();
            prodDto.Id = products.Id;
            prodDto.Name = products.Name;
            prodDto.Price = products.Price;
            prodDto.Description = products.Description;
            prodDto.Code = products.Code;
            return prodDto;
        }
    }
}
