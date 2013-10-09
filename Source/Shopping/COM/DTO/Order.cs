using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Order {
        public Order() { }
        public virtual int Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual System.Nullable<float> Quantity { get; set; }
        public virtual float Price { get; set; }
    }
}
