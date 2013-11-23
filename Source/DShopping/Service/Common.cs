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
            //var prodDto = Mapper.Map<Products, ProductDto>(products);
            ProductDto productDto = new ProductDto();
            productDto.Id = products.Id;
            float price = 0;
            string image = "";
            if (products.Price == null)
                price = 0;
            else price = (float)products.Price;
            IList<ProductDetails> IProdDetails = ProductDetailDAO.getAllProductDetailByTypeId(products.Id, CONST.STATUS.P_IMAGE);
            if (IProdDetails != null)
            {
                List<ProductDetails> prodDetails = IProdDetails.ToList();
                if (prodDetails.Count > 0)
                    image = prodDetails.ElementAt(0).Contents;
            }
            productDto.Name = products.Name;
            productDto.Code = products.Code;
            productDto.Description = products.Description;
            productDto.Price = price;
            productDto.Image = image;
            Categories newCat = CategoryDAO.getCategoryById(products.Category.CategoryId);
            productDto.Category = new CategoryDto()
            {
                CategoryId = newCat.CategoryId,
                name = newCat.Name

            };

            return productDto;
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
            float price = 0;
            string image = "";
            if (products.Price == null)
                price = 0;
            else price = (float)products.Price;
            IList<ProductDetails> IProdDetails = ProductDetailDAO.getAllProductDetailByTypeId(id, CONST.STATUS.P_IMAGE);
            if (IProdDetails != null)
            {
                List<ProductDetails> prodDetails = IProdDetails.ToList();
                if (prodDetails.Count > 0)
                    image = prodDetails.ElementAt(0).Contents;
            }

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

        public static HotCategoryDto ConvertToHotCategoryDto(Categories category)
        {
            var hotCategoryDto = new HotCategoryDto();
            hotCategoryDto.CategoryId = category.CategoryId;
            hotCategoryDto.Name = category.Name;
            List<Products> listProducts = null;
            if (ProductDAO.getAllProductByCategory(category.CategoryId) != null)
                listProducts = ProductDAO.getAllProductByCategory(category.CategoryId).ToList();
            hotCategoryDto.Products = ConvertToListProductDto(listProducts);
            return hotCategoryDto;
        }

        public static List<HotCategoryDto> ConvertToListHotCategoryDto(List<Categories> listProducts)
        {
            List<HotCategoryDto> newListProdDto = new List<HotCategoryDto>();
            foreach (Categories prods in listProducts)
            {
                newListProdDto.Add(ConvertToHotCategoryDto(prods));

            }
            return newListProdDto;
        }
        #endregion

        #region Comment Converter

        public static CommentDto ConvertToCommentDto(Comments comment)
        {
            CommentDto newCommentDto = new CommentDto();
            if (comment != null)
            {
                newCommentDto.Content = comment.Content;
                newCommentDto.Name = comment.Name;
                newCommentDto.Phone = comment.Phone;
                newCommentDto.Title = comment.Title;
                newCommentDto.ProductId = comment.Product.Id;
                newCommentDto.CreatedDate = ((comment.CreatedDate != null) ? (DateTime)comment.CreatedDate: DateTime.Now);
            }
            else return null;

            return newCommentDto;
        }

        public static List<CommentDto> ConvertToCommentDto(List<Comments> comments)
        {
            List<CommentDto> CommentDto = new List<CommentDto>();
            foreach (Comments comment in comments)
            {
                CommentDto.Add(ConvertToCommentDto(comment));
            }
            return CommentDto;
        }

        public static Comments ConvertToComments(CommentDto commentDto)
        {
            Comments comments = new Comments();
            if (commentDto != null)
            {
                comments.Title = commentDto.Title;
                comments.Status = StatusDAO.getStatusById(CONST.STATUS.ACTIVE);
                comments.Product = ProductDAO.getProductById(commentDto.ProductId);
                comments.Phone = commentDto.Phone;
                comments.Name = commentDto.Name;
                comments.Email = commentDto.Email;
                comments.CreatedDate = DateTime.Now;
                comments.Content = commentDto.Content;
            }
            return comments;
        }
        #endregion
    }
}
