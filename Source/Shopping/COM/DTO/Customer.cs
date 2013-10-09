using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Customer {
        public Customer() {
			Customers = new List<Customer>();
			Invoices = new List<Invoice>();
        }
        public virtual int CustomerID { get; set; }
        public virtual Status Status { get; set; }
        public virtual Customer Parent { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Usename { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual IList<Customer> Customers { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
    }
}
