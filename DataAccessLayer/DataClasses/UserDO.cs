namespace DataAccessLayer.DataClasses
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// AUTHOR: Giancarlo Rhodes
    /// COMPANY: Onshore Outsourcing
    /// DESCRIPTION: 
    /// </summary>
    public class UserDO
    {
       public Int64 UserId { get; set; }
       public Int64 LMSId { get; set; }
       public string Username { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string  Password { get; set; }
       public string Role { get; set; }
       public int Active { get; set; }
       public Int64 GroupId { get; set; }
       public Int64 CourseId { get; set; }
       public DateTime CreatedDate { get; set; }
       public Int64 CreatedUserId { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }


    }
}
