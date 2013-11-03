using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class ProductSuppliers {
        public virtual int Id { get; set; }
        public virtual Products Product { get; set; }
        public virtual Supplies Supplier { get; set; }
    }
}
