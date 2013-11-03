using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Invoices {
        public Invoices() {
			Orders = new List<Orders>();
        }
        public virtual int InvoiceId { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual ShippingMethods ShippingMethods { get; set; }
        public virtual DateTime OrderedTime { get; set; }
        public virtual DateTime? ExpectedDeliveryTime { get; set; }
        public virtual DateTime? ActualDeliveryTime { get; set; }
        public virtual IList<Orders> Orders { get; set; }
    }
}
