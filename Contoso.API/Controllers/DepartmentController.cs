using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contoso.Services;
using Contoso.Models;

namespace Contoso.API.Controllers
{
    //MVC and API inherit from different classes
    //MVC inherit from controller
    //API inherit from APIController

    [RoutePrefix("api/departments")]
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Department> GetDepartments()
        {
            var departments = _departmentService.GetAllDepartments();
            return departments;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetDepartmentById(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound, "No Department Found");
                return ResponseMessage(response);
            }
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, department));
        }
    }
}
