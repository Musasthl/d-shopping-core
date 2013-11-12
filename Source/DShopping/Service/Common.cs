using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DataTier.DAO;
using DataTier.Entities;
using Service.DTO;

namespace Service
{
    public class Common
    {
        public Common()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Mapper.AddProfile<ConverterProfile>();
        }

        #region Product Converter
        public static ProductDto ConvertToProductDto(Products products)
        {
            var prodDto = Mapper.Map<Products, ProductDto>(products);
            return prodDto;
        }

        public static List<ProductDto> ConvertToListProductDto(List<Products> listProducts)
        {
            List<ProductDto> newListProdDto = new List<ProductDto>();
            foreach (Products prods in listProducts)
            {
                newListProdDto.Add(ConvertToProductDto(prods));

            }
            return newListProdDto;
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

        #region Category Converter
        public static CategoryDto ConvertToCategoryDto(Categories products)
        {
            var prodDto = Mapper.Map<Categories, CategoryDto>(products);
            return prodDto;
        }

        public static List<CategoryDto> ConvertToListCategoryDto(List<Categories> listProducts)
        {
            List<CategoryDto> newListProdDto = new List<CategoryDto>();
            foreach (Categories prods in listProducts)
            {
                newListProdDto.Add(ConvertToCategoryDto(prods));

            }
            return newListProdDto;
        }
        #endregion
    }
}
