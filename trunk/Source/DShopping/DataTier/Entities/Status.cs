using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Status {
        public Status() {
			Categories = new List<Categories>();
			Customers = new List<Customers>();
			FAQs = new List<FAQs>();
			Invoices = new List<Invoices>();
			MessageReceivers = new List<MessageReceivers>();
			Messages = new List<Messages>();
			News = new List<News>();
            ProductTypeIds = new List<ProductDetails>();
			ProductDetails = new List<ProductDetails>();
			Products = new List<Products>();
			Supplies = new List<Supplies>();
			Users = new List<Users>();
        }
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Categories> Categories { get; set; }
        public virtual IList<Customers> Customers { get; set; }
        public virtual IList<FAQs> FAQs { get; set; }
        public virtual IList<Invoices> Invoices { get; set; }
        public virtual IList<MessageReceivers> MessageReceivers { get; set; }
        public virtual IList<Messages> Messages { get; set; }
        public virtual IList<News> News { get; set; }
        public virtual IList<ProductDetails> ProductTypeIds { get; set; }
        public virtual IList<ProductDetails> ProductDetails { get; set; }
        public virtual IList<Products> Products { get; set; }
        public virtual IList<Supplies> Supplies { get; set; }
        public virtual IList<Users> Users { get; set; }
    }
}
