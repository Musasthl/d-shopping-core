using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.DAO;
using DataTier.Entities;

namespace Service.DTO
{
    public class UserDTO
    {
        public string username { get; set; }
        public string password { get; set; }

        //UserDto()
        //{
        //}

        public void addUser(string username, string password)
        {
            User a = new User();
            a.Username = username;
            a.Password = password;
            UserDAO.Add(a);
        }

    }
}
