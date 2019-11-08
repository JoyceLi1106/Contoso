using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;

namespace Contoso.Data
{
    public class EnrollmentRepository
    {
        public Enrollment GetEnrollmentById(int id)
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.Enrollments.Where(d => d.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.Enrollments.ToList();
            }
        }

        public Enrollment GetEnrollmentByGrade(string grade)
        {
            using (var db = new ContosoDataDbContext())
            {
                return db.Enrollments.Where(d => d.Grade == grade).FirstOrDefault();
            }
        }

        public void Create(Enrollment enrollment)
        {
            using (var db = new ContosoDataDbContext())
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
            }
        }
    }
}
