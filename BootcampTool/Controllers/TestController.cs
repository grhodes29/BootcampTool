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
            List<User> model = new List<User>();
            da = new DataAccess();
            // TESTING ONLY
            // hard coding userId
            int userId = 0;  // Andrew Leon   

            try
            {
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
                // TODO: implement error logging
                da.LogError(error);
                return View();
            }
            
                          
        }


    }
}