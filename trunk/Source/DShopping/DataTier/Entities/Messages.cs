using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Messages {
        public Messages() {
			MessageReceivers = new List<MessageReceivers>();
        }
        public virtual int MessageId { get; set; }
        public virtual Users CreatedUser { get; set; }
        public virtual Status Status { get; set; }
        public virtual string Title { get; set; }
        public virtual string Contents { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual IList<MessageReceivers> MessageReceivers { get; set; }
    }
}
