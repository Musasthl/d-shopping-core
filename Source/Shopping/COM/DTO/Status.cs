using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Status {
        public Status() {
			Customers = new List<Customer>();
			Invoices = new List<Invoice>();
			ProductDetails = new List<ProductDetail>();
			Products = new List<Product>();
            Users = new List<User>();
        }
        public virtual string StatusID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Customer> Customers { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
        public virtual IList<ProductDetail> ProductDetails { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual IList<User> Users { get; set; }
    }
}
