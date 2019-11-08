using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data;
using Contoso.Models;

namespace Contoso.Services
{
    public class CourseService
    {
        CourseRepository Courserepo;
        public CourseService()
        {
            Courserepo = new CourseRepository();
        }

        public Course GetCourseById(int id)

        {
            return Courserepo.GetCourseById(id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return Courserepo.GetAllCourse();
        }

        public Course GetHighestCredits()
        {
            return Courserepo.GetHighestCredit();
            //var result = Courserepo.GetHighestCredit();
            //Console.WriteLine("The highest credit Course is: {0}", result);
        }

        public Course GetCourseByTitle(string title)
        {
            return Courserepo.GetCourseByTitle(title);
            //Console.WriteLine("Enter the title: ");
            //string title = Console.ReadLine();
            //var result = Courserepo.GetCourseByTitle(title);
            //if (result != null)
            //{
            //    Console.WriteLine(result.Id + result.Title + result.Credits);
            //}
            //else
            //{
            //    Console.WriteLine("Don't have this course.");
            //}
        }

        public void AddCourse(Course course)
        {
            Courserepo.Create(course);
        }
    }
}
