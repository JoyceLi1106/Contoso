using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Models;
using Contoso.Services;

namespace ContosoMVC.Controllers
{
    public class EnrollmentController : Controller
    {
        private EnrollmentService _enrollmentService;
        public EnrollmentController()
        {
            _enrollmentService = new EnrollmentService();
        }
        // GET: Enrollment
        public ActionResult Index()
        {
            var enrollments = _enrollmentService.GetEnrollments();
            ViewBag.EnrollmentGrade = enrollments;              
            return View(enrollments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Enrollment enrollment)
        {
            try
            {
                enrollment.CourseId = 1;
                enrollment.StudentId = 6;
                enrollment.CreatedDate = DateTime.Now;
                enrollment.UpdatedDate = DateTime.Now;

                _enrollmentService.AddEnrollment(enrollment);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var enrollment = _enrollmentService.GetByEnrollId(id);
            return View(enrollment);
        }
    }
}