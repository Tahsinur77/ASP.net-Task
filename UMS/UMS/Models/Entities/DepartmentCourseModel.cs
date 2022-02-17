using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models.Entities
{
    public class DepartmentCourseModel:DepartmentModel
    {
        public List<CourseModel> Courses { set; get; }
        public DepartmentCourseModel()
        {
            Courses = new List<CourseModel>();
        }
    }
}