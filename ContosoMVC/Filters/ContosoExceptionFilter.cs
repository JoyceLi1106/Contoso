using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoMVC.Filters
{
    public class ContosoExceptionFilter : HandleErrorAttribute
    {
        public ContosoExceptionFilter()
        {

        }


        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName); //return the handle model to the view in the shared folder 
            filterContext.Result = new ViewResult {
                ViewName = View,
                MasterName = Master, //navigation bar on the website  
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData 
            };
            string exceptionPath = filterContext.HttpContext.Request.Path + filterContext.HttpContext.Request.QueryString;

            //log exception information like (all of information are in filterContext
            //1. exception getting from filtercontext.exception
            //2. inner message of the exception 
            //3. DateTime -> DateTime.Now 
            //4. Action method Name and ControllerName 
            //5. The whole stack traces -> get from filtercontext.exception
            //6. exception Path (URL) 
            //7. Log above details using NLog to textfiles 

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500; 

            base.OnException(filterContext);
        }
    }
}