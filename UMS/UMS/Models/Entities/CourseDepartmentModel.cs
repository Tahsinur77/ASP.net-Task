using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models.Entities
{
    public class CourseDepartmentModel:CourseModel
    {
        public DepartmentModel Dept { set; get; }
    }
}