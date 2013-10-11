using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Order {
        public virtual int OrderID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual int Quantity { get; set; }
    }
}
