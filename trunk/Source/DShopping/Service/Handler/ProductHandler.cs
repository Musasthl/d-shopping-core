using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTO;
using DataTier.Entities;
using DataTier.DAO;
using DataTier;


namespace Service.Handler
{
    public class ProductHandler
    {
        public bool AddNewProduct(ProductDto productDto)
        {
            try
            {
                if (productDto == null) return false;
                Products product = new Products();
                product = Common.ConvertToProduct(productDto);
                ProductDAO.Execute(product, Entity.PRODUCT, ExecuteType.ADD);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ProductDto> GetProductsByCategoryId(int categoryId)
        {
            var listProduct = ProductDAO.getAllProductByCategory(categoryId);
            if (listProduct != null)
            {
                var result = Common.ConvertToListProductDto(listProduct.ToList());
                return result;
            }

            return new List<ProductDto>();
        }

        public static List<ProductOverviewDto> getNewestProduct()
        {
            IList<Products> INewest = ProductDAO.getNewestProduct(CONST.PRODUCT.NO_NEWEST);
            if (INewest == null) return null;
            List<Products> newestProduct = INewest.ToList();

            return Common.convertOverview(newestProduct);
        }

        public ProductDto GetProductDetailById(int productId)
        {
            var productDetail = ProductDAO.getProductById(productId);
            if (productDetail != null)
            {
                var result = Common.ConvertToProductDto(productDetail);
                return result;
            }
            return new ProductDto();
        }

        public ProductDto GetProductDetailByCode(string productCode)
        {
            var productDetail = ProductDAO.getProductByCode(productCode);
            if (productDetail != null)
            {
                var result = Common.ConvertToProductDto(productDetail);
                return result;
            }
            return new ProductDto();
        }

        public List<ProductDto> GetSearchProduct(string searchValue)
        {
            var searchResults = ProductDAO.GetProductByCodeOrName(searchValue);
            if (searchResults != null)
            {
                return Common.ConvertToListProductDto(searchResults.ToList());
            }
            return new List<ProductDto>();
        }

        public List<ProductDto> GetOtherProducts()
        {
            var results = ProductDAO.GetOtherProducts(CONST.CATEGORY.CAT_SHOPMUABAN);
            if (results != null)
            {
                return Common.ConvertToListProductDto(results.ToList());
            }
            return null;
        }
		
		public static List<CommentDto> GetAllComment(int productId)
        {
            List<CommentDto> allComment = new List<CommentDto>();
            IList<Comments> IComments = CommentDAO.getAllCommentByProduct(productId);
            if(IComments != null)
                allComment = Common.ConvertToCommentDto(IComments.ToList());

            return allComment;

        }

        public bool AddComment(CommentDto commentDto)
        {
            try
            {
                CommentDAO.Execute(Common.ConvertToComments(commentDto), Entity.COMMENT, ExecuteType.ADD);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteComment(CommentDto commentDto)
        {
            try
            {
                CommentDAO.Execute(Common.ConvertToComments(commentDto), Entity.COMMENT, ExecuteType.REMOVE);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
