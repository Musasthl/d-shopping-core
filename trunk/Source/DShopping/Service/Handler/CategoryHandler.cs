using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.DAO;
using DataTier.Entities;
using Service.DTO;
using AutoMapper;
using DataTier;

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
            List<Categories> cats = new List<Categories>();
            if(CategoryDAO.getAllActiveCategoryByParent(ParentId) != null)
                cats = CategoryDAO.getAllActiveCategoryByParent(ParentId).ToList();

            catDto = Common.ConvertToListCategoryDto(cats);
            // Sorted by Position

            return catDto;
        }

        public List<HotCategoryDto> GetHotCategories()
        {
            try
            {
                var hotCatDto = new List<HotCategoryDto>();
                var hotCats = CategoryDAO.GetHotCategories(CONST.CATEGORY.CAT_HOTCATEGORY, CONST.CATEGORY.CAT_TRANBAO).ToList();
                hotCatDto = Common.ConvertToListHotCategoryDto(hotCats);
                return hotCatDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void AddCategory(String CategoryName, String ParentName)
        {
            Categories category = new Categories();
            category.Name = CategoryName;
            category.Status = StatusDAO.getStatusById(CONST.STATUS.ACTIVE);
            DAO.Execute(category, Entity.CATEGORY, ExecuteType.ADD);
            category = CategoryDAO.getCategoryByName(CategoryName);
            CategoryRelations rel = new CategoryRelations();
            rel.Parent = CategoryDAO.getCategoryById(CONST.CATEGORY.CAT_TRANBAO);
            rel.Child = category;
            DAO.Execute(rel, Entity.CATEGORYRELATION, ExecuteType.ADD);
        }
    }
}
