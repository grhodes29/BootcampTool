
namespace BootcampTool.Common
{

    using BootcampTool.Models;
    using DataAccessLayer.DataClasses;
    using System;
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

        public static UserDO Map(User u) {

            UserDO _result = new UserDO();

            _result.FirstName = u.Firstname;
            _result.Active = 1;
            _result.CreatedDate = DateTime.Now;
            _result.CreatedUserId = 0;
            _result.Email = u.Email;
      
            return _result;

        }


        public static UserDO Map(Register r)
        {

            UserDO _result = new UserDO();

            _result.FirstName = r.User.Firstname;
            _result.LastName = r.User.LastName;
            _result.Username = r.User.Username;
            _result.Password = r.User.Password;
            _result.LMSId = r.SelectedLMSCourseId;
            _result.GroupId = r.SelectedLMSGroupId;
            _result.Active = 1;
            _result.CreatedDate = DateTime.Now;
            _result.CreatedUserId = 0;
            _result.Email = r.User.Email;
            _result.Role = r.User.Role;

            return _result;

        }

    }
}