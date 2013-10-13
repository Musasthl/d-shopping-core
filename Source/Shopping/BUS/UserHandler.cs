using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.DTO;
using DAL.DAO;
using COM;

namespace BUS
{
    public class UserHandler
    {
        public static bool CreateNewUser(User User)
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

        public static bool Register(User User)
        {
            try
            {
                return UserDAO.Add(User);
            }
            catch (Exception ex)
            {
                Logger.getInstance().log(ex.ToString());
                return false;
            }
        }
    }
}
