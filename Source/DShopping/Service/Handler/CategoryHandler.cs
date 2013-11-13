using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.DAO;
using DataTier.Entities;
using Service.DTO;
using AutoMapper;

namespace Service.Handler
{
    public class CategoryHandler
    {
        
        public List<CategoryDto> getAllCategory()
        {
            Mapper.AddProfile<ConverterProfile>();
            List<CategoryDto> catDto = new List<CategoryDto>();
            List<Categories> cats = DAO.getAll().ToList();

            catDto = Common.ConvertToListCategoryDto(cats);
            // Sorted by Position

            return catDto;
        }

        public List<CategoryDto> getAllCategoryByParentId(int ParentId)
        {
            Mapper.AddProfile<ConverterProfile>();
            List<CategoryDto> catDto = new List<CategoryDto>();
            List<Categories> cats = CategoryDAO.getAllActiveCategoryByParent(ParentId).ToList();

            catDto = Common.ConvertToListCategoryDto(cats);
            // Sorted by Position

            return catDto;
        }
    }
}
