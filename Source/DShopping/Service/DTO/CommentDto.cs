using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.DTO
{
    public class CommentDto
    {
        public String Name { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public String Phone { get; set; }
        public int ProductId { get; set; }
        public String Email { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
