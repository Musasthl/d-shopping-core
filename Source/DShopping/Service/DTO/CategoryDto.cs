using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.DAO;
using DataTier.Entities;

namespace Service.DTO
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string name { get; set; }
        public int? ParentId { get; set; }
        public string StatusId { get; set; }

        public CategoryDto() { }
        public CategoryDto(int id, string name)
        {
            this.CategoryId = id;
            this.name = name;
        }


    }

   
}
