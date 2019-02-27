

namespace BootcampTool.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;


    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult ClockInOut()
        {
            return View();
        }
    }
}