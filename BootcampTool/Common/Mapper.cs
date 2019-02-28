
namespace BootcampTool.Common
{

    using BootcampTool.Models;
    using DataAccessLayer.DataClasses;
    using System.Collections.Generic;

    /// <summary>
    /// AUTHOR: Giancarlo Rhodes
    /// COMPANY: Onshore Outsourcing
    /// DESCRIPTION: All my mapping methods will be in here
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// DESCRIPTION: maps a list of UserDO objects to list of User objects
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public static List<User> Map(List<UserDO> inList) {

            // this is what will be returned
            List<User> list = new List<User>();

            // loop for going the mapping
            foreach (UserDO uDO in inList)
            {
                User u = new User();
                u.Active = uDO.Active;
                u.Firstname = uDO.FirstName;
                u.LastName = uDO.LastName;
                u.Id = uDO.UserId;
                u.Username = uDO.Username;
                u.Password = uDO.Password;
                u.Role = uDO.Role;
                u.Email = uDO.Email;
                u.Phone = uDO.Phone;
                list.Add(u);
            }

            return list;
        }

    }
}