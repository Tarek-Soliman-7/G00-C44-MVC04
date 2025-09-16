using Demo.BusinessLogicBLL.Services;
using Demo.BusinessLogicBLL.Services.Interfaces;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
