using System;
using System.Text;
using System.Collections.Generic;


namespace COM.DTO {
    
    public class Category {
        public Category() {
			Categories = new List<Category>();
			Products = new List<Product>();
        }
        public virtual int CategoryId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Category> Categories { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}
