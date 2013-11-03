using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Address {
        public Address() {
			Customers = new List<Customers>();
			Supplies = new List<Supplies>();
        }
        public virtual int Id { get; set; }
        public virtual string AddressVal { get; set; }
        public virtual string Wards { get; set; }
        public virtual string District { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual IList<Customers> Customers { get; set; }
        public virtual IList<Supplies> Supplies { get; set; }
    }
}
