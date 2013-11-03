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
        public string username { get; set; }
        public string password { get; set; }

        //UserDto()
        //{
        //}

        public void addUser()
        {
            FAQs faq = new FAQs();
            faq.Position = 10;
            faq.Question = "test";
            faq.Answer = "test answer";
            DAO.Execute(faq, Entity.FAQ, ExecuteType.ADD);
        }

    }
}
