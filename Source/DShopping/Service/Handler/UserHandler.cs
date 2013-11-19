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
    public class UserHandler
    {
        public void register(UserDto user)
        {
            Users newUser = new Users();

            newUser.CreatedDate = DateTime.Now;
            newUser.Role = RoleDAO.getRoleById(CONST.ROLE.NORMALUSER);
            newUser.Status = null;
        }

        public static bool AdminLogin(String username, String password)
        {
            Users adminUser = UserDAO.getUserByName(username);
            if (adminUser == null) return false;
            else
            {
                if (Encrypt.EncodePassword(password).Equals(adminUser.Password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
