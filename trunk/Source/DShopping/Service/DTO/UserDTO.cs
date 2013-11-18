using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataTier.DAO;
using DataTier.Entities;

namespace Service.DTO
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Login()
        {
            if (Username == "admin" && Password == "admin")
                return true;
            else return false;
        }
    }
}
