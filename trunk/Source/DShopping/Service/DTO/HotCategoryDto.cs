using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.DAO;
using DataTier.Entities;

namespace Service.DTO
{
    public class HotCategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
