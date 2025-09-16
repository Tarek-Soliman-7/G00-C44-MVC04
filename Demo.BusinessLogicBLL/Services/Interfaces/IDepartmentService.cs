using Demo.BusinessLogicBLL.DTOS;

namespace Demo.BusinessLogicBLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreateDepartmentDto departmentDto);
        IEnumerable<DepartmentDto> GetAllDepts();
        DepartmentDetailsDto? GetDeptById(int id);
        bool RemoveDepartment(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}