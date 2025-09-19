using Demo.DataAccessDAL_Infrastructure_.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicBLL.DTOS
{
    public class CreateEmployeeDto
    {
        public string Name {  get; set; }=string.Empty;
        public string Email {  get; set; }=string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; }= string.Empty;
        public Gender Gender {  get; set; }
        public EmpType EmpType { get; set; }
        public DateOnly HiringDate { get; set; }

        public decimal? Salary {  get; set; }

    }
}
