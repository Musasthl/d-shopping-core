﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.DTO
{
    public class MessageDto
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
