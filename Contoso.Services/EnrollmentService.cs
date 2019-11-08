using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data;
using Contoso.Models;

namespace Contoso.Services
{
    public class EnrollmentService
    {
        EnrollmentRepository enrollrepo;
        public EnrollmentService()
        {
            enrollrepo = new EnrollmentRepository();
        }

        public Enrollment GetByEnrollId(int id)
        {
            return enrollrepo.GetEnrollmentById(id);
            //Console.WriteLine("Enter the Id: ");
            //int id = Convert.ToInt32(Console.ReadLine());
            //Enrollment result = enrollrepo.GetEnrollmentById(id);
            //if (result != null)
            //{
            //    Console.WriteLine(result.Id + result.Grade + result.StudentId + result.CourseId);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid ID");
            //}
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            return enrollrepo.GetEnrollments();
        }

        public Enrollment GetEnrollByGrade(string grade)
        {
            return enrollrepo.GetEnrollmentByGrade(grade);
            //Console.WriteLine("Enter the grade: ");
            //string grade = Console.ReadLine();
            //Enrollment result = enrollrepo.GetEnrollmentByGrade(grade);
            //if (grade != null)
                //Console.WriteLine(result.Id + result.Grade + result.StudentId + result.CourseId);
        }


        public void AddEnrollment(Enrollment enrollment)
        {
            enrollrepo.Create(enrollment);
        }
    }
}
