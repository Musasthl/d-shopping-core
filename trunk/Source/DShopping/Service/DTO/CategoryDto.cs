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
        private List<CategoryDto> childCategory;

        public CategoryDto() { }
        public CategoryDto(int id, string name)
        {
            this.CategoryId = id;
            this.name = name;
        }

        public List<CategoryDto> getChildCategory()
        {
            // get child
            return childCategory;
        }

    }

   
}
