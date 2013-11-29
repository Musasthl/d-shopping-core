using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
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

        public static int AdminLogin(String username, String password)
        {
            Users adminUser = UserDAO.getUserByName(username);
            if (adminUser == null) return CONST.ROLE.INVALID;
            else
            {
                if ((password).Equals(adminUser.Password))  // Encode Later
                {
                    return adminUser.Role.Id;
                }
                else
                {
                    return CONST.ROLE.INVALID;
                }
            }
        }

        public static void ChangePassword(String username, String password)
        {
            Users adminUser = UserDAO.getUserByName(username);
            if (adminUser == null) return;
            else
            {
                adminUser.Password = password;
                UserDAO.Execute(adminUser, Entity.USER, ExecuteType.UPDATE);
            }
        }
    }
}
