using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Models;
using Contoso.Services;

namespace ContosoMVC.Controllers
{
    public class CourseController : Controller
    {
        private CourseService _courseService;
        public CourseController()
        {
            _courseService = new CourseService();
        }
        // GET: Course
        public ActionResult Index()
        {
            var courses = _courseService.GetCourses();
            ViewBag.AllCourses = courses;
            return View(courses);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                course.DepartmentId = 3;
                course.UpdatedDate = DateTime.Now;

                _courseService.AddCourse(course);

                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var course = _courseService.GetCourseById(id);
            return View(course);
        }

      
    }

}