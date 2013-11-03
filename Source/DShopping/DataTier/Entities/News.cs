using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class News {
        public virtual int Id { get; set; }
        public virtual Users CreatedUser { get; set; }
        public virtual Status Status { get; set; }
        public virtual string Title { get; set; }
        public virtual string Image { get; set; }
        public virtual string Contents { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
    }
}
