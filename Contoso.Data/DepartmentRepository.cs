using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;
using System.Data.Entity;
using Contoso.Models;

namespace Contoso.Data
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository 
    {
        public DepartmentRepository(ContosoDataDbContext context) : base(context) //access base class constructor
        {
        }

        public Department GetDepartmentByName(string name)
        {
            var department = _dbContext.Departments.FirstOrDefault(d => d.Name == name);
            return department;
        }

        public Department GetDepartmentByName()
        {
            throw new NotImplementedException();
        }
    }
    public interface IDepartmentRepository:IRepository<Department> //for new methods
    {
        //Department GetDepartmentByName(string name);
        Department GetDepartmentByName();
    }

}


        //public object ModelState { get; private set; }

        //public Department GetDepartmentById(int id)
        //{
        //    using (var db = new ContosoDataDbContext())
        //    {
        //        return db.Departments.Where(d => d.Id == id).FirstOrDefault();
                
        //    }
        //}

        //public void GetDepartmentById()
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable <Department> GetAllDepartment()
        //{
        //    using (var db = new ContosoDataDbContext())
        //    {
        //        return db.Departments.ToList();
        //    }
        //}

        ////public Department GetDepartmentByID(int id)
        ////{
        ////    throw new NotImplementedException();
        ////}

        //public Department GetDepartmentByName (string Name)
        //{
        //    using (var db = new ContosoDataDbContext())
        //    {
        //        return db.Departments.Where(d => d.Name == Name).Single();
        //    }
        //}

        //public Department GetHighestBudgetDepartment()
        //{
        //    using (var db = new ContosoDataDbContext())
        //    {
        //        return db.Departments.OrderByDescending(d => d.Budget).FirstOrDefault();
        //    }
        //}

        //public void Create(Department department)
        //{
        //    using (var db = new ContosoDataDbContext())
        //    {
        //        db.Departments.Add(department);
        //        db.SaveChanges();
        //    }
        //}

        //public void Update(Department department)
        //{
        //  using (var db = new ContosoDataDbContext())
        //    {
        //        var departmentById = db.Departments.Where(d => d.Id == department.Id).FirstOrDefault();
        //        departmentById.Name = department.Name;
        //        departmentById.Budget = department.Budget;
        //        departmentById.startDate = department.startDate;
        //        db.SaveChanges();
        //    }
        //}
