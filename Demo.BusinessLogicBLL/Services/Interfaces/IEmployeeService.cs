using Demo.BusinessLogicBLL.DTOS;

namespace Demo.BusinessLogicBLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        int AddEmployee(CreateEmployeeDto employeeDto);
        IEnumerable<EmployeeDto> GetAllEmps();
        EmployeeDetailsDto? GetEmpById(int id);
        bool RemoveEmployee(int id);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
    }
}