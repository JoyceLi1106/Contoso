using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Models;
using Contoso.Services;
using ContosoMVC.Filters;

namespace ContosoMVC.Controllers
{
    [ContosoExceptionFilter]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private string departname;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET: Department
        public ActionResult Index()
        {
            //int i = 0;
            //int x = 1;
            //int y = x / i;

            var departments = _departmentService.GetAllDepartments();
            //ViewData["depts"] = departments;
            ViewBag.DepartmentCount = departments.Count();
            return View(departments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            //Get the data from the FormCollection and call Service Layer 
            //Save to database 
            try
            {
                //var departmentname = form["departmentname"];
                //var budget = form["budget"];
                //var startdate = form["startdate"];

                //Department department = new Department();
                //department.Name = departmentname;
                //department.Budget = budget;
                //department.startDate = startdate;
                department.InstructorId = 2;
                department.CreatedDate = DateTime.Now;
                department.UpdatedDate = DateTime.Now;

                //call the service layer
                //_departmentService.AddDepartment(department);

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
            //var department = _departmentService.GetById(id);
            //    return View(department);
            return RedirectToAction("Index");
            }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            //_departmentService.EditDepartment(department);
            //return RedirectToAction("Index");
            return View("Edit");
        }
        
    }
}