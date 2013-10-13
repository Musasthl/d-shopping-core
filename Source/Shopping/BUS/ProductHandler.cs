using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.DTO;
using DAL.DAO;
using COM;

namespace BUS
{
    public class ProductHandler
    {
        public static bool CreateNewUser(Product Product)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {
                Logger.getInstance().log(ex.ToString());
                return false;
            }
        }
    }
}
