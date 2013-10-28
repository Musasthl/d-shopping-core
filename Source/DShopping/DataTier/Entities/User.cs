using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class User {
        public virtual int UserId { get; set; }
        public virtual Role Roles { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}
