using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Orders {
        public virtual int Id { get; set; }
        public virtual Products Product { get; set; }
        public virtual Invoices Invoice { get; set; }
        public virtual Units Unit { get; set; }
        public virtual float Quantity { get; set; }
        public virtual float? Price { get; set; }
    }
}
