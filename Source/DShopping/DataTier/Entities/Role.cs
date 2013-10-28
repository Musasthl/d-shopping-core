using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Role {
        public Role() {
			Users = new List<User>();
        }
        public virtual int RoleId { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<User> Users { get; set; }
    }
}
