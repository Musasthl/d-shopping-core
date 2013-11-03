using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {
    
    public class Categories {
        public Categories() {
            Parent = new List<CategoryRelations>();
            Child = new List<CategoryRelations>();
			Products = new List<Products>();
        }
        public virtual int CategoryId { get; set; }
        public virtual Status Status { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Image { get; set; }
        public virtual int? Position { get; set; }
        public virtual IList<CategoryRelations> Parent { get; set; }
        public virtual IList<CategoryRelations> Child { get; set; }
        public virtual IList<Products> Products { get; set; }
    }
}
