using Demo.BusinessLogicBLL.DTOS;
using Demo.BusinessLogicBLL.Services;
using Demo.BusinessLogicBLL.Services.Interfaces;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService employeeService,
        IWebHostEnvironment _Env, ILogger<EmployeeController> _logger) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;
        #region Index
        public IActionResult Index()
        {
            var Emp = _employeeService.GetAllEmps();
            return View(Emp);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDto createEmployeeDto)
        {
            if (ModelState.IsValid)
            {

                //return View(Dept);
                try
                {
                    int Emp = _employeeService.AddEmployee(createEmployeeDto);
                    if (Emp > 0)
                    {
                        //return View("Index",_departmentService.GetAllDepts());
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Cannot Be Created !");
                    }

                }
                catch (Exception ex)
                {
                    //Development
                    if (_Env.IsDevelopment())
                    {
                        _logger.LogError($"Department Cannot Be Created Because: {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Department Cannot Be Created Because: {ex}");
                        return View("ErrorView");
                    }
                    //Deployment
                }

            }
            return View(createEmployeeDto);

        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();//400
            }
            var Emp = _employeeService.GetEmpById(id.Value);
            if (Emp is null) return NotFound();
            return View(Emp);


        }
        #endregion

        #region Edit 
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();//400
            }
            var Emp = _employeeService.GetEmpById(id.Value);
            if (Emp is null) return NotFound();//404
            var updatedEmpVM = new EmployeeEditViewModel()
            {
                Age = Emp.Age,
                Salary = Emp.Salary,
                Address = Emp.Address,
                Email = Emp.Email,
                EmpType = Emp.EmployeeType,
                Gender = Emp.Gender,
                HiringDate = Emp.HiringDate.HasValue?Emp.HiringDate.Value:default,
                Name = Emp.Name,
                PhoneNumber = Emp.PhoneNumber,
                IsActive = Emp.IsActive

            };
            return View(updatedEmpVM);

        }
        [HttpPost]

        public IActionResult Edit([FromRoute] int? id, EmployeeEditViewModel updatedEmpVM)
        {
            if (ModelState.IsValid)
            {

                //return View(Dept);
                try
                {
                    if (!id.HasValue) return BadRequest();
                    var UpdatedEmpDto = new UpdatedEmployeeDto()
                    {
                        Id = id.Value,
                        Age = updatedEmpVM.Age,
                        Salary = updatedEmpVM.Salary,
                        Address = updatedEmpVM.Address,
                        Email = updatedEmpVM.Email,
                        EmpType = updatedEmpVM.EmpType,
                        Gender = updatedEmpVM.Gender,
                        HiringDate = updatedEmpVM.HiringDate,
                        Name = updatedEmpVM.Name,
                        PhoneNumber = updatedEmpVM.PhoneNumber,
                        IsActive = updatedEmpVM.IsActive,
                        
                        
                        
                    };
                    int Emp = _employeeService.UpdateEmployee(UpdatedEmpDto);
                    if (Emp > 0)
                    {
                        //return View("Index",_departmentService.GetAllDepts());
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Cannot Be Updated !");
                    }

                }
                catch (Exception ex)
                {
                    //Development
                    if (_Env.IsDevelopment())
                    {
                        _logger.LogError($"Employee Cannot Be Updated Because: {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Employee Cannot Be Updated Because: {ex}");
                        return View("ErrorView", ex);

                    }
                    //Deployment
                }

            }
            return View(updatedEmpVM);

        }
        #endregion


        #region Delete
        //[HttpGet]

        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue)return BadRequest();//400 
        //    var Dept = _departmentService.GetDeptById(id.Value);
        //    if (Dept is null) return NotFound();
        //    return View(Dept);
        ///}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool IsDeleted = _employeeService.RemoveEmployee(id);
                if (IsDeleted)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Cannot Be Deleted !!");
                }
            }
            catch (Exception ex)
            {
                if (_Env.IsDevelopment())
                {
                    _logger.LogError($"Employee Cannot Be Updated Because: {ex.Message}");
                }
                else
                {
                    _logger.LogError($"Employee Cannot Be Updated Because: {ex}");
                    return View("ErrorView", ex);
                }
                //Deployment
            }
            return RedirectToAction("Delete", new { id });
        }
        #endregion
    }

}
