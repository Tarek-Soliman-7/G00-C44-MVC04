using Demo.DataAccessDAL_Infrastructure_.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicBLL.DTOS
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public decimal? Salary { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly? HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmpType EmployeeType { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateOnly? ModifiedOn { get; set; }
    }
}
