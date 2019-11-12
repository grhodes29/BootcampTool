namespace BootcampTool.Controllers
{
    using BootcampTool.Common;
    using BootcampTool.Models;
    using DataAccessLayer;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    public class AccountController : Controller
    {
        private readonly string apiKey;
        public DataAccess da { get; set; }


        public AccountController()
        {
            apiKey = ConfigurationManager.AppSettings["apiKey"];
            da = new DataAccess();
        }


        // GET: Account
        [HttpGet]
        public ActionResult ClockInOut()
        {
            TimeEntry model = new TimeEntry();
            return View(model);
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
            Register model = new Register();
            return View(model);
        }


        [HttpPost]
        public ActionResult Register(Register model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    model.User.Role = Role.Learner_Ty;
                    int result = da.CreateUser(Mapper.Map(model));

                    if (result == 1) {
                        model.Message.State = "success";
                        model.Message.Description = "User registered succesfully.";
                    }
                    else
                    {
                        model.Message.State = "error";
                        model.Message.Description = "Failed to register user.";
                    } 

                    return View(model);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception error)
            {

                da.LogError(error);
                return View(model);
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


        [HttpGet]
        public ActionResult ViewLMSGroups()
        {
            //Generate Group options from web request.

            WebClient client = new WebClient { Credentials = new NetworkCredential(apiKey, "") };

            string resp = client.DownloadString("https://onshore.talentlms.com/api/v1/groups");

            List<LMSGroup> groups = JsonConvert.DeserializeObject<List<LMSGroup>>(resp);

            ViewBag.Groups = new List<SelectListItem>();
            foreach (LMSGroup group in groups)
            {
                ViewBag.Groups.Add(new SelectListItem { Text = group.Name, Value = group.Id.ToString() });
            }

            string response = client.DownloadString("https://onshore.talentlms.com/api/v1/courses");
            List<LMSCourse> courses = JsonConvert.DeserializeObject<List<LMSCourse>>(response);
            ViewBag.Courses = new List<SelectListItem>();
            foreach (LMSCourse course in courses)
            {
                ViewBag.Courses.Add(new SelectListItem { Text = course.Name, Value = course.Id.ToString() });
            }

            //Generate options from json response.
            return View();
        }



    }
}