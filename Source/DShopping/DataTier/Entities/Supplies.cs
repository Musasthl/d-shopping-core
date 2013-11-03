using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Supplies {
        public Supplies() {
			ProductSuppliers = new List<ProductSuppliers>();
        }
        public virtual int Id { get; set; }
        public virtual Address Address { get; set; }
        public virtual Status Status { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactJobTitle { get; set; }
        public virtual string PhoneOffice { get; set; }
        public virtual string PhoneMobile { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string TaxCode { get; set; }
        public virtual IList<ProductSuppliers> ProductSuppliers { get; set; }
    }
}
