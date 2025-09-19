using Demo.BusinessLogicBLL.Services;
using Demo.BusinessLogicBLL.Services.Interfaces;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService employeeService,
        IWebHostEnvironment _Env, ILogger<EmployeeController> _logger) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;
        public IActionResult Index()
        {
            var Emp=_employeeService.GetAllEmps();
            return View(Emp);
        }
    }
}
