using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Product {
        public Product() {
			Orders = new List<Order>();
			ProductDetails = new List<Productdetail>();
        }
        public virtual int ProductId { get; set; }
        public virtual Category Categories { get; set; }
        public virtual Status Status { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual int? Price { get; set; }
        public virtual string Quantity { get; set; }
        public virtual DateTime? AvailableFrom { get; set; }
        public virtual int? Discount { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual IList<Productdetail> ProductDetails { get; set; }
    }
}
