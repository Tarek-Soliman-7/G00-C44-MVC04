using Demo.DataAccessDAL_Infrastructure_.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicBLL.DTOS
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly HiringDate { get; set; }
        public EmpType EmployeeType { get; set; }
        public DateOnly DateOfCreation { get; set; }


    }
}
