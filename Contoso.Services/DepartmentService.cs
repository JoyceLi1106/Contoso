using Contoso.Data;
using Contoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository) //Any class that implement this interface can be passed into as parameter 
        {
            _departmentRepository = departmentRepository; 
        }
        public void CreateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public Department GetDepartmentByName(string name)
        {
            return _departmentRepository.GetDepartmentByName();
        }

        public int GetTotalDepartmentCount()
        {
            throw new NotImplementedException();
        }
    }

    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        int GetTotalDepartmentCount();
        Department GetDepartmentById(int id);
        Department GetDepartmentByName(string name);
        void CreateDepartment(Department department);

    }

    public class DepartmentService2 : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService2(IDepartmentRepository departmentRepository) //Any class that implement this interface can be passed into as parameter 
        {
            _departmentRepository = departmentRepository;
        }
        public void CreateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentByName(string name)
        {
            return _departmentRepository.GetDepartmentByName();
        }

        public int GetTotalDepartmentCount()
        {
            throw new NotImplementedException();
        }
    }
}
