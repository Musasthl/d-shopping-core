using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.DAO;
using DataTier.Entities;
using Service.DTO;

namespace Service.Handler
{
    public class CategoryHandler
    {
        public List<CategoryDto> getAllCategory()
        {
            List<CategoryDto> catDto = new List<CategoryDto>();
            List<Categories> cats = DAO.getAll().ToList();
            // List<Categories> cats2 = DAO.getAll();
            foreach (Categories cat in cats)
            {
                if(cat.Status.Id == CONST.STATUS.ACTIVE)
                    catDto.Add(new CategoryDto(cat.CategoryId, cat.Name));
            }
            // Sorted by Position

            return catDto;
        }
    }
}
