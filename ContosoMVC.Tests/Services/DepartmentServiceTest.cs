using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contoso.Data;
using Contoso.Models;
using Contoso.Services;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Moq;

namespace ContosoMVC.Tests.Services
{
    [TestClass]
    public class DepartmentServiceTest
    {
        private IDepartmentService _departmentService;
        private Mock<IDepartmentRepository> _mockDepartmentRepository;
        private List<Department> _departments;

        [TestInitialize]
        public void Initilize()
        {
            _mockDepartmentRepository = new Mock<IDepartmentRepository>();//create the mockDepartmentRepository class automatically in the runtime
            _departmentService = new DepartmentService(_mockDepartmentRepository.Object);
            _departments = new List<Department> //initialize the mock data field we created
            {
                new Department
                {
                    Id = 1,
                    Name = "CS",
                    Budget = 300,
                    startDate = DateTime.Now
                },
                new Department
                {
                    Id = 2,
                    Name = "Biology",
                    Budget = 1000,
                    startDate = DateTime.Now
                },
                new Department
                {
                    Id = 3,
                    Name = "Physics",
                    Budget = 500,
                    startDate = DateTime.Now
                },
                new Department
                {
                    Id = 4,
                    Name = "Law",
                    Budget = 2500,
                    startDate = DateTime.Now
                }
            };
            _mockDepartmentRepository.Setup(d => d.GetAll()).Returns(_departments);
            _mockDepartmentRepository.Setup(d => d.GetById(It.IsAny<int>())).Returns((int s)=>_departments.First(x=>x.Id ==s));
        }
        [TestMethod]
        public void CheckDepartmentCountFromFakeData() //method name should be self-explainatory; use in-memory data to test 
        {
            //_departmentService = new DepartmentService(new MockDepartmentRepository());
            var departments = _departmentService.GetAllDepartments();
            Assert.IsNotNull(departments);
            Assert.AreEqual(4, departments.Count());           
        }

        [TestMethod]
        public void CheckDepartmentIDFromFakeData()
        {
            var department = _departmentService.GetDepartmentById(3);
            Assert.AreEqual("Physics", department.Name);
        }
    }

    //public class MockDepartmentRepository : IDepartmentRepository
    //{
    //    public void Add(Department entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Department entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Expression<Func<Department, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Department Get(Expression<Func<Department, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Department> GetAll()
    //    {
    //        var departments = new List<Department>
    //        {
    //            new Department
    //            {
    //                Id = 1,
    //                Name = "CS",
    //                Budget = 300,
    //                startDate = DateTime.Now
    //            },
    //            new Department
    //            {
    //                Id = 1,
    //                Name = "Biology",
    //                Budget = 1000,
    //                startDate = DateTime.Now
    //            },
    //            new Department
    //            {
    //                Id = 1,
    //                Name = "Physics",
    //                Budget = 500,
    //                startDate = DateTime.Now
    //            },
    //            new Department
    //            {
    //                Id = 1,
    //                Name = "Law",
    //                Budget = 2500,
    //                startDate = DateTime.Now
    //            }
    //        };
    //        return departments;
    //    }

    //    public Department GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int GetCount(Expression<Func<Department, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Department GetDepartmentByName()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Department> GetMany(Expression<Func<Department, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void SaveChanges()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Department entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
