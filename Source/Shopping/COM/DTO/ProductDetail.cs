using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class ProductDetail {
        public virtual int Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Status ProductType { get; set; }
        public virtual string Descriptions { get; set; }
    }
}
