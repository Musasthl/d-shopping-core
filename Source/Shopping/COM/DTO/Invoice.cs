using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Invoice {
        public Invoice() {
			Orders = new List<Order>();
        }
        public virtual int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }
}
