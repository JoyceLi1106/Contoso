using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;

namespace Contoso.Data
{
    public class CourseRepository
    {
        public Course GetCourseById(int id)
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.Courses.Where(d => d.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<Course> GetAllCourse()
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.Courses.ToList(); 
            }
        }

        public Course GetCourseByTitle(string title)
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.Courses.Where(d => d.Title == title).Single();
            }
        }

        public Course GetHighestCredit()
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.Courses.OrderByDescending(d => d.Credits).FirstOrDefault();
            }
        }

        public void Create(Course course)
        {
            using (var db = new ContosoDataDbContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }
    }


}
