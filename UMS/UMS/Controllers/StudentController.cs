using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models.Database;
using UMS.Models.Entities;

namespace UMS.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                UniversityEntities db = new UniversityEntities();
                db.Students.Add(stu);
                db.SaveChanges();
                return RedirectToAction("StudentList");
            }
            return View();
        }

        public ActionResult StudentList()
        {
            UniversityEntities db = new UniversityEntities();
            var studentList = db.Students.ToList();
            List<StudentDepartmentModel> stuList = new List<StudentDepartmentModel>();
            

            foreach (var student in studentList)
            {
                DepartmentModel dept = new DepartmentModel();
                dept.Name = student.Department.Name;
                dept.Id = student.Department.Id;

                


                //by mapper
                //DepartmentModel deptMapper = _mapper.Map<DepartmentModel>(student.Department);
                //StudentDepartmentModel stuMapper = _mapper.Map<StudentDepartmentModel>(student);

                StudentDepartmentModel stu = new StudentDepartmentModel();
                stu.Name = student.Name;
                stu.DeptId = student.DeptId;
                stu.Dept = dept;



                stuList.Add(stu);

            }
            return View(stuList);
        }


    }
}