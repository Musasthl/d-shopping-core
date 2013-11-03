using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class MessageReceivers {
        public virtual int Id { get; set; }
        public virtual Users User { get; set; }
        public virtual Messages Message { get; set; }
        public virtual Status Status { get; set; }
    }
}
