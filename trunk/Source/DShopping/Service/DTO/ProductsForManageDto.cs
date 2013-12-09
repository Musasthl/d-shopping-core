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
        public string LinkUpdate { get { return "<span onclick='test(\"" + this.Code.ToString() + "\")'>Update</span>"; } }
        public string LinkDelete { get { return "<span onclick='test(\""+this.Code.ToString()+"\")'>Delete</span>"; } }
        public string Image1{get { return "<img src='../../Contents/Images/Product/" + this.Image + "' />"; }}
    }
}
