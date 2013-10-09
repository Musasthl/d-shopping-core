using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Status {
        public Status() {
			Customers = new List<Customer>();
			Invoices = new List<Invoice>();
			ProductDetails = new List<Productdetail>();
			Products = new List<Product>();
        }
        public virtual string StatusID { get; set; }
        public virtual string StatusDesc { get; set; }
        public virtual IList<Customer> Customers { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
        public virtual IList<Productdetail> ProductDetails { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}
