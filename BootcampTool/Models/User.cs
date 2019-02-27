namespace BootcampTool.Models
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;


    /// <summary>
    /// AUTHOR: Giancarlo Rhodes
    /// COMPANY: Onshore Outsourcing
    /// DESCRIPTION: 
    /// </summary>
    public class User
    {

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Active { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}