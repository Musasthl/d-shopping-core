using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier.DAO;
using DataTier.Entities;
using Service.DTO;

namespace Service
{
    public class Common
    {
        #region Product Converter

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

        public static List<ProductOverviewDto> convertOverview(List<Products> listProducts)
        {
            List<ProductOverviewDto> newListProdDto = new List<ProductOverviewDto>();
            foreach (Products prods in listProducts)
            {
                newListProdDto.Add(convertOverview(prods));

            }
            return newListProdDto;
        }
        public static ProductOverviewDto convertOverview(Products products)
        {
            int id = products.Id;
            string name = products.Name;
            float price ;
            if(products.Price == null) 
                price = 0;
            else price = (float)products.Price;

            List<ProductDetails> prodDetails = ProductDetailDAO.getAllProductDetailByTypeId(CONST.STATUS.P_IMAGE).ToList();
            string image = prodDetails.ElementAt(0).Contents;
            ProductOverviewDto prodDto = new ProductOverviewDto(id, name, image, price);
            
            return prodDto;
        }
        #endregion
    }
}
