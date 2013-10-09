using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Status {
        public Status() {
			Categories = new List<Category>();
			Customers = new List<Customer>();
			Invoices = new List<Invoice>();
			Products = new List<Product>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Descriptions { get; set; }
        public virtual IList<Category> Categories { get; set; }
        public virtual IList<Customer> Customers { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}
