using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class ProductDetailsDto 
    {
        public int Id { get; set; }  
        public ProductDto Product { get; set; }
        public string Contents { get; set; }
    }
}
