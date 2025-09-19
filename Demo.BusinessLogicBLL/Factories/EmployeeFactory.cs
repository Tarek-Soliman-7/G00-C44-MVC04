using Demo.BusinessLogicBLL.DTOS;
using Demo.DataAccessDAL_Infrastructure_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicBLL.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeDto ToEmployeeDto(this Employee E)
        {
            return new EmployeeDto
            {
                Id = E.Id,
                Name = E.Name,
                HiringDate = E.HiringDate.HasValue?DateOnly.FromDateTime(E.HiringDate.Value):default,
                Email = E.Email,
                EmployeeType = E.EmployeeType,
                PhoneNumber = E.PhoneNumber,
                DateOfCreation = E.CreatedOn.HasValue ? DateOnly.FromDateTime(E.CreatedOn.Value) : default,


            };
            
        }
        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee E)
        {
            return new EmployeeDetailsDto
            {
                Salary = E.Salary!.Value,
                Id = E.Id,
                Address = E.Address,
                Age = E.Age!.Value,
                Email = E.Email,
                EmployeeType=E.EmployeeType,
                Gender = E.Gender,
                HiringDate = E.HiringDate.HasValue ? DateOnly.FromDateTime(E.HiringDate.Value) : default,
                Name = E.Name,
                PhoneNumber=E.PhoneNumber
                
            };
        }

        public static Employee ToModel(this CreateEmployeeDto employeeDto)
        {
            return new Employee()
            {
                Email = employeeDto.Email,
                Name = employeeDto.Name,
                Salary = employeeDto.Salary,
                Address = employeeDto.Address,
                EmployeeType = employeeDto.EmpType,
                Gender = employeeDto.Gender,
                HiringDate = employeeDto.HiringDate.ToDateTime(new TimeOnly()),
                PhoneNumber = employeeDto.PhoneNumber

            };
        }

        public static Employee ToModel(this UpdatedEmployeeDto employeeDto)
        {
            return new Employee()
            {
                Id = employeeDto.Id,
                Email = employeeDto.Email,
                Name = employeeDto.Name,
                Salary = employeeDto.Salary,
                Address = employeeDto.Address,
                EmployeeType = employeeDto.EmpType,
                Gender = employeeDto.Gender,
                HiringDate = employeeDto.HiringDate.ToDateTime(new TimeOnly()),
                PhoneNumber = employeeDto.PhoneNumber

            };
        }
    }
}
