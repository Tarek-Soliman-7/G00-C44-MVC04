using Demo.BusinessLogicBLL.DTOS;
using Demo.DataAccessDAL_Infrastructure_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicBLL.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department D)
        {
            return new DepartmentDto
            {
                DeptId = D.Id,
                Code = D.Code,
                Name = D.Name,
                Description = D.Description!,
                DateOfCreation = D.CreatedOn.HasValue ? DateOnly.FromDateTime(D.CreatedOn.Value) : default,
                
            };


        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department Dept)
        {
            return new DepartmentDetailsDto
            {
                Id = Dept.Id,
                Name = Dept.Name,
                Description = Dept.Description,
                Code = Dept.Code,
                CreatedBy = Dept.CreatedBy,
                CreatedOn = Dept.CreatedOn.HasValue ? DateOnly.FromDateTime(Dept.CreatedOn.Value) : default,
                ModifiedBy = Dept.ModifiedBy,
                ModifiedOn = Dept.ModifiedOn.HasValue ? DateOnly.FromDateTime(Dept.ModifiedOn.Value) : default,
                IsDeleted = Dept.IsDeleted,
            };
        }
        public static Department ToModel(this CreateDepartmentDto departmentDto)
        {
            return new Department()
            {
                Description = departmentDto.Description,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())

            }; 
        }

        public static Department ToModel(this UpdatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id= departmentDto.Id,
                Description = departmentDto.Description,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())

            };
        }

    }
}
