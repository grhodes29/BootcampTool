namespace BootcampTool.Controllers
{


    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using BootcampTool.Common;
    using BootcampTool.Models;
    using DataAccessLayer;

    public class TestController : Controller
    {

        public DataAccess da { get; set; }
      
        // GET: Test
        public ActionResult DataTableExample()
        {
            return View();
        }


        public ActionResult MessageExample()
        {
            Message model = new Message();
            model.State = "error";

            if (ModelState.IsValid)
            {

                if (model.State == "success")
                {
                    //do something
                    model.Description = "Success message text.";
                    return View(model);
                }
                else {

                    model.Description = "Error occurred !!!!!!";
                    return View(model);
                }

            }
            else
            {
                return View();
            }

    
        }



        public ActionResult SelectUsers()
        {
            List<User> list = new List<User>();
            da = new DataAccess();
            // TESTING ONLY
            // hard coding userId
            int userId = 0;  // Andrew Leon   

            list = Mapper.Map(da.GetUsers(userId));

            ListOfUsers model = new ListOfUsers(list);


            if (ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return View();
            }


        }


    }
}