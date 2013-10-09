using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Order {
        public virtual int OrderID { get; set; }
        public virtual Product Products { get; set; }
        public virtual Invoice Invoices { get; set; }
        public virtual string Quantity { get; set; }
    }
}
