using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.DTO
{
    public class ProductsForManageDto
    {
        public int Id { get; set; }
        //public CategoryDto Category { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Code { get; set; }
        public float? Price { get; set; }
        //public float? QuantityAvailable { get; set; }
        //public float? QuantityPending { get; set; }
        //public IList<ProductDetailsDto> ProductDetails { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string IsActive { get; set; }
        public string LinkUpdate {get { return "<a href='javascript:;'>Update</a>"; }}
        public string LinkDelete { get { return "<a href='javascript:;'>Delete</a>"; } }
    }
}
