using Demo.DataAccessDAL_Infrastructure_.Data.Enums;

namespace Demo.Presentation.ViewModels
{
    public class EmployeeEditViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public EmpType EmpType { get; set; }
        public DateOnly HiringDate { get; set; }
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; }

    }
}
