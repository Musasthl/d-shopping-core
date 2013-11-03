using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class FAQs {
        public virtual int Id { get; set; }
        public virtual Status Status { get; set; }
        public virtual string Question { get; set; }
        public virtual string Answer { get; set; }
        public virtual int? Position { get; set; }
    }
}
