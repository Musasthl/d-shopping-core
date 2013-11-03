using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Users {
        public Users() {
			MessageReceivers = new List<MessageReceivers>();
			Messages = new List<Messages>();
			News = new List<News>();
        }
        public virtual int Id { get; set; }
        public virtual Status Status { get; set; }
        public virtual Roles Role { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string Code { get; set; }
        public virtual IList<MessageReceivers> MessageReceivers { get; set; }
        public virtual IList<Messages> Messages { get; set; }
        public virtual IList<News> News { get; set; }
    }
}
