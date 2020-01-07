using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class homeController : Controller
    {
        // GET: home

        TestProjectsEntities dbcontext = new TestProjectsEntities();

        public ActionResult Index()
        {

            List<SelectListItem> CourseName = new SelectList(dbcontext.Courses.ToList(), "Id", "CourseName").ToList();
            //RoomStatusType.Insert(0, new SelectListItem() { Text = "Room type", Value = "" });
            ViewBag.CourseDrodown = CourseName;
            var Course =  dbcontext.Courses.ToList();
            Student StudentModel = new Student();
            StudentViewModel model = new StudentViewModel { StudentCoures = Course , StudnetModel = StudentModel };
            return View(model);
        }

        public JsonResult GetCourses()
        {

            List<SelectListItem> CourseName = new SelectList(dbcontext.Courses.ToList(), "Id", "CourseName").ToList();
            //RoomStatusType.Insert(0, new SelectListItem() { Text = "Room type", Value = "" });
            ViewBag.CourseDrodown = CourseName;
            var Course = dbcontext.Courses.Select(m=>m.CourseName).ToList();
            Student StudentModel = new Student();
            //StudentViewModel model = new StudentViewModel { StudentCoures = Course, StudnetModel = StudentModel };
            return Json(Course,JsonRequestBehavior.AllowGet);
        }
    }
}