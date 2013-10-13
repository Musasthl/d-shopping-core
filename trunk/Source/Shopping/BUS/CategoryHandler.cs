using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.DTO;
using DAL.DAO;
using COM;

namespace BUS
{
    public class CategoryHandler
    {
        public static bool addCategory(Category Category)
        {
            try
            {
                return CategoryDAO.Add(Category);
            }
            catch (Exception ex)
            {
                Logger.getInstance().log(ex.ToString());
                return false;
            }
        }
        public static List<Category> getAllParentCategory()
        {
            List<Category> allCat = CategoryDAO.GetAll().ToList();
            List<Category> parentcat = new List<Category>();
            foreach (Category cat in allCat)
            {
                if (cat.Parent == null) parentcat.Add(cat);
            }
            return parentcat;
        }
    }
}
