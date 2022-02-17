using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models.Database;
using UMS.Models.Entities;

namespace UMS.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                UniversityEntities db = new UniversityEntities();
                db.Departments.Add(dept);
                db.SaveChanges();
                return RedirectToAction("DepartmentList");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DepartmentList()
        {
            UniversityEntities db = new UniversityEntities();
            var deptList = db.Departments.ToList();
            List<DepartmentModel> dList = new List<DepartmentModel>();
            foreach(var dept in deptList)
            {
                DepartmentModel d = new DepartmentModel();
                d.Id = dept.Id;
                d.Name = dept.Name;
                dList.Add(d);
            }
            return View(dList);
        }
    }
}