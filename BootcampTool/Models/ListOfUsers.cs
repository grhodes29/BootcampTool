using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootcampTool.Models
{
    public class ListOfUsers
    {
        List<User> Users { get; set; }

        public ListOfUsers(List<User> inList) {

            Users = inList;

        }
    }
}