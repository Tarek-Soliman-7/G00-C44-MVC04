using Demo.BusinessLogicBLL.DTOS;
using Demo.BusinessLogicBLL.Factories;
using Demo.BusinessLogicBLL.Services.Interfaces;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicBLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Methods Interacts with Repository

        //5 CRUD Operations

        // GET ALL => Id, Code, Name, Description, CreationOn
        public IEnumerable<EmployeeDto> GetAllEmps()
        {
            var Emps = _employeeRepository.GetAll();
            return Emps.Select(E => E.ToEmployeeDto());

        }

        // GET BY ID

        public EmployeeDetailsDto? GetEmpById(int id)
        {
            var Emp = _employeeRepository.GetById(id);
            if (Emp is null) return null;
            //Mapping [Manula Mapping]
            return Emp.ToEmployeeDetailsDto();

        }

        // ADD
        public int AddEmployee(CreateEmployeeDto employeeDto)
            =>
            _employeeRepository.Add(employeeDto.ToModel());


        // UPDATE
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        =>
            _employeeRepository.Update(employeeDto.ToModel());

        // REMOVE
        public bool RemoveEmployee(int id)
        {
            var Dept = _employeeRepository.GetById(id);
            if (Dept is null) return false;
            int flag = _employeeRepository.Remove(Dept);
            return flag > 0 ? true : false;
        }
    }
}
