using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Productdetail {
        public virtual int Id { get; set; }
        public virtual Product Products { get; set; }
        public virtual Status Status { get; set; }
        public virtual string Descriptions { get; set; }
    }
}
