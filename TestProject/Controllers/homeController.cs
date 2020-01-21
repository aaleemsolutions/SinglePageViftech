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

            List<SelectListItem> CourseName = new SelectList(dbcontext.Classes.ToList(), "Id", "ClassName").ToList();
            //RoomStatusType.Insert(0, new SelectListItem() { Text = "Room type", Value = "" });
            ViewBag.CourseDrodown = CourseName;
            var Course =  dbcontext.Courses.ToList();
            Student StudentModel = new Student();
            StudentViewModel model = new StudentViewModel { StudentCoures = Course , StudnetModel = StudentModel };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string studentname,string ClassId,string courseid)
        {
            var student = new Student();
            student.ClassId = Convert.ToInt32(ClassId);
            student.CourseId = Convert.ToInt32(courseid);
            student.StudentName = studentname;

            try
            {
                dbcontext.Students.Add(student);
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {

                
            }




            return View();
        }

        public JsonResult GetCourses()
        {

            List<SelectListItem> CourseName = new SelectList(dbcontext.Classes.ToList(), "id", "ClassName").ToList();
            //RoomStatusType.Insert(0, new SelectListItem() { Text = "Room type", Value = "" });
            ViewBag.CourseDrodown = CourseName;
            var Course = dbcontext.Courses.Select(m=>m.CourseName).ToList();
            Student StudentModel = new Student();
            //StudentViewModel model = new StudentViewModel { StudentCoures = Course, StudnetModel = StudentModel };
            return Json(Course,JsonRequestBehavior.AllowGet);
        }
        public JsonResult StudentData()
        {

            
            var Course = dbcontext.Students.Select(m=>new { StudentName =  m.StudentName,StudentClass = m.Class.ClassName,StudentCourse = m.Courses.CourseName }).ToList();
            
            //StudentViewModel model = new StudentViewModel { StudentCoures = Course, StudnetModel = StudentModel };
            return Json(new { data = Course }, JsonRequestBehavior.AllowGet);
        }
    }
}