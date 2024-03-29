﻿using System;
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
        public static Products ConvertToProduct(ProductDto prodDto)
        {
            Products product = new Products();
            product.Category = CategoryDAO.getCategoryById(prodDto.CategoryId);
            if (prodDto.Code == null || prodDto.Code == "")
                product.Code = null;
            else product.Code = prodDto.Code;
            product.CreatedDate = DateTime.Now;
            product.Description = prodDto.Description;
            product.Name = prodDto.Name;
            product.Price = prodDto.Price;
            product.Status = StatusDAO.getStatusById(CONST.STATUS.ACTIVE);

            ProductDetails productDetail = new ProductDetails();
            productDetail.ProductTypeId = StatusDAO.getStatusById(CONST.STATUS.P_IMAGE);
            productDetail.Status = StatusDAO.getStatusById(CONST.STATUS.ACTIVE);
            productDetail.CreatedDate = DateTime.Now;
            productDetail.Contents = prodDto.Image;
            productDetail.Product = product;

            product.ProductDetails.Add(productDetail);

            if (prodDto.Id != null)
            {
                product.Id = prodDto.Id;
            }
            return product;
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

        public static ProductsForManageDto ConvertToProductsForManageDto(Products products)
        {
            var productDto = new ProductsForManageDto();
            productDto.Id = products.Id;
            float price;
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
            productDto.IsActive = products.Status.Id;
            productDto.CategoryId = products.Category.CategoryId;
            productDto.Quantity = products.Quantity;

            return productDto;
        }

        public static List<ProductsForManageDto> ConvertToListProductForManageDtos(List<Products> listProducts)
        {
            var newListProdDto = new List<ProductsForManageDto>();
            foreach (Products prods in listProducts)
            {
                newListProdDto.Add(ConvertToProductsForManageDto(prods));

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
            string code = products.Code;
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

            ProductOverviewDto prodDto = new ProductOverviewDto(id, name, image, price,code);

            return prodDto;
        }
        #endregion

        #region Category Converter
        public static CategoryDto ConvertToCategoryDto(Categories categories)
        {
            var categoryDto = new CategoryDto();
            categoryDto.CategoryId = categories.CategoryId;
            categoryDto.name = categories.Name;
            categoryDto.StatusId = categories.Status.Id;
            
            return categoryDto;
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
                newCommentDto.CreatedDate = ((comment.CreatedDate != null) ? (DateTime)comment.CreatedDate : DateTime.Now);
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

        #region Message Converter

        public static MessageDto ConvertToMessageDto(Messages Message)
        {
            MessageDto newMessageDto = new MessageDto();
            if (Message != null)
            {
                newMessageDto.Contents = Message.Contents;
                newMessageDto.Address = Message.Address;
                newMessageDto.Email = Message.Email;
                newMessageDto.MessageId = Message.MessageId;
                newMessageDto.Name = Message.Name;
                newMessageDto.Phone = Message.Phone;
                newMessageDto.Title = Message.Title;
                newMessageDto.CreatedDate = ((Message.CreatedDate != null) ? (DateTime)Message.CreatedDate : DateTime.Now);
            }
            else return null;

            return newMessageDto;
        }

        public static List<MessageDto> ConvertToMessageDto(List<Messages> comments)
        {
            List<MessageDto> CommentDto = new List<MessageDto>();
            foreach (Messages comment in comments)
            {
                CommentDto.Add(ConvertToMessageDto(comment));
            }
            return CommentDto;
        }

        public static Messages ConvertToMessages(MessageDto MessagesDto)
        {
            Messages Messages = new Messages();
            if (MessagesDto != null)
            {
                Messages.Title = MessagesDto.Title;
                Messages.Status = StatusDAO.getStatusById(CONST.STATUS.UNREAD);
                Messages.Phone = MessagesDto.Phone;
                Messages.Name = MessagesDto.Name;
                Messages.Email = MessagesDto.Email;
                Messages.Address = MessagesDto.Address;
                Messages.CreatedDate = DateTime.Now;
                Messages.Contents = MessagesDto.Contents;
            }
            return Messages;
        }
        #endregion


    }
}
