namespace BootcampTool.Controllers
{
    using BootcampTool.Common;
    using BootcampTool.Models;
    using DataAccessLayer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AccountController : Controller
    {

        public DataAccess da { get; set; }


        // GET: Account
        [HttpGet]
        public ActionResult ClockInOut()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    return View();
                }
            }
            catch (Exception error)
            {

                da.LogError(error);
                return View();
            }
        }


        [HttpPost]
        public ActionResult Login(User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    return View();
                }
            }
            catch (Exception error)
            {

                da.LogError(error);
                return View();
            }
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(User model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception error)
            {

                da.LogError(error);
                return View();
            }

        }

        [HttpGet]
        public ActionResult Users()
        {

            List<User> model = new List<User>();
            da = new DataAccess();

            try
            {
                int userId = 0; // get all
                model = Mapper.Map(da.GetUsers(userId));

                if (ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception error)
            {
                da.LogError(error);
                return View();
            }

        }

        [HttpGet]
        public ActionResult InactivateUser(int userToInactivate)
        {

            List<User> model = new List<User>();
            return View("Users", model);
        }


        [HttpGet]
        public ActionResult EditUser(int userToEdit)
        {

            List<User> model = new List<User>();
            return View("Users", model);
        }

    }
}