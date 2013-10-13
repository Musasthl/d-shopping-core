using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Role {
        public Role() {
            Users = new List<User>();
        }
        public virtual int RoleID { get; set; }
        public virtual string RoleName { get; set; }
        public virtual IList<User> Users { get; set; }
    }
}
