namespace BootcampTool.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class Register
    {

        public User User { get; set; }

        public Message Message { get; set; }

        private List<LMSCourse> _LMSCourseList { get; set; }

        private List<LMSGroup> _LMSGroupList { get; set; }

        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Need to select a value.")]
        public int SelectedLMSCourseId { get; set; }

        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Need to select a value.")]
        public int SelectedLMSGroupId { get; set; }

        public Register() {

            _LMSCourseList = new List<LMSCourse>() {
                new LMSCourse { Id = 0, Name = "Select Course" },
                new LMSCourse { Id = 1, Name = "Test1" },
                new LMSCourse { Id = 2, Name = "Test2" }
            };

            _LMSGroupList = new List<LMSGroup>() {
                new LMSGroup { Id = 0, Name = "Select Group" },
                new LMSGroup { Id = 1, Name = "Group1" },
                new LMSGroup { Id = 2, Name = "Group2" }
            };

            Message = new Message();
            User = new User();
        }
    
        public IEnumerable<SelectListItem> LMSCourses
        {
            get { return new SelectList(_LMSCourseList, "Id", "Name"); }
        }


        public IEnumerable<SelectListItem> LMSGroups
        {
            get { return new SelectList(_LMSGroupList, "Id", "Name"); }
        }
    }
}