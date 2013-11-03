using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class ProductDetails {
        public virtual int Id { get; set; }
        public virtual Products Product { get; set; }
        public virtual Status Status { get; set; }
        public virtual Status ProductTypeId { get; set; }
        public virtual string Contents { get; set; }
    }
}
