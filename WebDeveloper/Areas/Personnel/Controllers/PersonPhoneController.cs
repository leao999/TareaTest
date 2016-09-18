﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Model;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    public class PersonPhoneController : PersonBaseController<PersonPhone>
    {
        // GET: Personnel/PersonPhone
        public ActionResult Index()
        {
            return View();
        }
    }
}