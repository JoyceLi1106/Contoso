using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Models;
using Contoso.Services;

namespace ContosoMVC.Controllers
{
    public class PeopleController : Controller
    {
        private PeopleService _peopleService;
        public PeopleController()
        {
            _peopleService = new PeopleService();
        }
        // GET: People
        public ActionResult Index()
        {
            var people = _peopleService.GetPeople();
            //ViewData["depts"] = departments;
            ViewBag.PeopleCount = people.Count();
            return View(people);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(People people)
        {
            try
            {
                people.CreatedDate = DateTime.Now;
                people.UpdateDate = DateTime.Now;
                people.LastLockedDateTime = DateTime.Now;

                _peopleService.AddPeople(people);

                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var people = _peopleService.GetPeopleByID(id);
            return View(people);
        }
    }
}