using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Units {
        public Units() {
			Orders = new List<Orders>();
			Products = new List<Products>();
        }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Orders> Orders { get; set; }
        public virtual IList<Products> Products { get; set; }
    }
}
