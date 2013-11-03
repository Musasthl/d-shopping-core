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
        public int id { get; set; }
        public string name { get; set; }
        private List<CategoryDto> childCategory;

        public CategoryDto() { }
        public CategoryDto(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }

    public class CategoryList
    {
        private List<CategoryDto> category;
        CategoryList()
        {

        }

        public void getAllCatogory()
        {
            List<Object> srcCategory = DAO.getAll();
            foreach (Categories cat in srcCategory)
            {
                CategoryDto newCategoryDTO = new CategoryDto();
                category.Add(newCategoryDTO);
            }
        }
    }
}
