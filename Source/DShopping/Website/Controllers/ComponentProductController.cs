﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Service.Handler;

namespace Website.Controllers
{
    public class ComponentProductController : Controller
    {
        //
        // GET: /ComponentProduct/

        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductList()
        {
            return View();
        }

        
    }
}
