using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models.Entities
{
    public class DepartmentStudentModel:DepartmentModel
    {
        public List<StudentModel> Students { set; get; }

        public DepartmentStudentModel()
        {
            Students = new List<StudentModel>();
        }
    }
}