using System;
using System.Text;
using System.Collections.Generic;


namespace DataTier.Entities {

    public class CategoryRelations
    {
        public virtual int Id { get; set; }
        public virtual Categories Parent { get; set; }
        public virtual Categories Child { get; set; }
    }
}
