using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMS.Models.Database;

namespace UMS.Models.Entities
{
    public class AutoMapping:Profile
    {

        public AutoMapping()
        {
            CreateMap<Department,DepartmentModel>();
            //CreateMap<Student, StudentModel>();
            //CreateMap<Student, StudentDepartmentModel>();
        }
    }
}