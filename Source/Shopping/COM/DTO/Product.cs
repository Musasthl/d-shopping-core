using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Product {
        public Product() {
			Orders = new List<Order>();
			ProductDetails = new List<ProductDetail>();
        }
        public virtual int Id { get; set; }
        public virtual Category Category { get; set; }
        public virtual Status Status { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Price { get; set; }
        public virtual float Quantity { get; set; }
        public virtual DateTime? AvailableFrom { get; set; }
        public virtual int? Discount { get; set; }
        public virtual string Unit { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual IList<ProductDetail> ProductDetails { get; set; }
    }
}
