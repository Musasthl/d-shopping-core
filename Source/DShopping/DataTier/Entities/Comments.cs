using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Comments {
        public virtual int Id { get; set; }
        public virtual Products Products { get; set; }
        public virtual Status Status { get; set; }
        public virtual string Contents { get; set; }
        public virtual string Title { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
    }
}
