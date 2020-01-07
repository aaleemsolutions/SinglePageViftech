using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class StudentViewModel
    {
        public Student StudnetModel { get; set; }

        public List<Courses> StudentCoures{ get; set; }
    }
}