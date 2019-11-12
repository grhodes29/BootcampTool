using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootcampTool.Models
{
    public class TimeEntry
    {
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }

        public string ClockInTime { get; set; }
        public string ClockOutTime { get; set; }
    }
}