using Demo.BusinessLogicBLL.DTOS;
using Demo.BusinessLogicBLL.Factories;
using Demo.BusinessLogicBLL.Services.Interfaces;
using Demo.DataAccessDAL_Infrastructure_.Data.Contexts;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces;
using Demo.DataAccessDAL_Infrastructure_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicBLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // Methods Interacts with Repository

        //5 CRUD Operations

        // GET ALL => Id, Code, Name, Description, CreationOn
        public IEnumerable<DepartmentDto> GetAllDepts()
        {
            var Depts = _departmentRepository.GetAll();
            return Depts.Select(D => D.ToDepartmentDto());

        }

        // GET BY ID

        public DepartmentDetailsDto? GetDeptById(int id)
        {
            var Dept = _departmentRepository.GetById(id);
            if (Dept is null) return null;
            //Mapping [Manula Mapping]
            return Dept.ToDepartmentDetailsDto();

        }

        // ADD
        public int AddDepartment(CreateDepartmentDto departmentDto)
            =>
            _departmentRepository.Add(departmentDto.ToModel());


        // UPDATE
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        =>
            _departmentRepository.Update(departmentDto.ToModel());

        // REMOVE
        public bool RemoveDepartment(int id)
        {
            var Dept = _departmentRepository.GetById(id);
            if (Dept is null) return false;
            int flag = _departmentRepository.Remove(Dept);
            return flag > 0 ? true : false;
        }
    }
}
