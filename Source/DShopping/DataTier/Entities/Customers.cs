using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Customers {
        public Customers() {
            Childs = new List<Customers>();
			Invoices = new List<Invoices>();
			Users = new List<Users>();
        }
        public virtual int CustomerId { get; set; }
        public virtual Address Address { get; set; }
        public virtual Status Status { get; set; }
        public virtual Customers Parent { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneMobile { get; set; }
        public virtual string Avatar { get; set; }
        public virtual string IdentityPassport { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string JobTitle { get; set; }
        public virtual string PhoneOffice { get; set; }
        public virtual string Website { get; set; }
        public virtual string TaxCode { get; set; }
        public virtual string Fax { get; set; }
        public virtual IList<Customers> Childs { get; set; }
        public virtual IList<Invoices> Invoices { get; set; }
        public virtual IList<Users> Users { get; set; }
    }
}
