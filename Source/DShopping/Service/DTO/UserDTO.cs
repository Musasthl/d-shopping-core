﻿using System;
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

    }
}