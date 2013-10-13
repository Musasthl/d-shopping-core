using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class User {
        public virtual int UserID { get; set; }
        public virtual Status Status { get; set; }
        public virtual Role Role { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
    }
}
