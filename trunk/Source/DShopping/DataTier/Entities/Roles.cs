using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Roles {
        public Roles() {
			Users = new List<Users>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Users> Users { get; set; }
    }
}
