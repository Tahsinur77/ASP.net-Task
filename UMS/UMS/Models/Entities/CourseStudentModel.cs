using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models.Entities
{
    public class CourseStudentModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}