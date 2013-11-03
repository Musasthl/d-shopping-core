using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class ShippingMethods {
        public ShippingMethods() {
			Invoices = new List<Invoices>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Invoices> Invoices { get; set; }
    }
}
