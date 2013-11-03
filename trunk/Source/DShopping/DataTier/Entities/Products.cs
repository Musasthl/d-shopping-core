using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Products {
        public Products() {
			Orders = new List<Orders>();
			ProductDetails = new List<ProductDetails>();
			ProductSuppliers = new List<ProductSuppliers>();
        }
        public virtual int Id { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Status Status { get; set; }
        public virtual Units Unit { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Quantity { get; set; }
        public virtual string Code { get; set; }
        public virtual float? Price { get; set; }
        public virtual float? QuantityAvailable { get; set; }
        public virtual float? QuantityPending { get; set; }
        public virtual IList<Orders> Orders { get; set; }
        public virtual IList<ProductDetails> ProductDetails { get; set; }
        public virtual IList<ProductSuppliers> ProductSuppliers { get; set; }
    }
}
