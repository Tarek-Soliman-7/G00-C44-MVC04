using Demo.DataAccessDAL_Infrastructure_.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessDAL_Infrastructure_.Models
{
    public class Employee:BaseEntity
    {
        public int Id {  get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }=string.Empty;
        [Range(24,50)]
        public int? Age {  get; set; }
        [Required(ErrorMessage = "Address must be in format [123-Street-City-Country].")]
        public string Address {  get; set; }=string.Empty;
        public bool? IsActive {  get; set; }
        public decimal? Salary {  get; set; }
        [EmailAddress]
        public string Email {  get; set; }= string.Empty;
        public string PhoneNumber { get; set; }= string.Empty;
        public DateTime? HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmpType EmployeeType { get; set; }

       
    }
}
