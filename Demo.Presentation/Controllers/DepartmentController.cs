using Demo.BusinessLogicBLL.DTOS;
using Demo.BusinessLogicBLL.Services;
using Demo.BusinessLogicBLL.Services.Interfaces;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService departmentService,
        IWebHostEnvironment _Env, ILogger<DepartmentController> _logger) : Controller
    {
        private readonly IDepartmentService _departmentService = departmentService;

        #region Index
        public IActionResult Index()
        {
            var Dept = _departmentService.GetAllDepts();
            return View(Dept);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto createDepartmentDto)
        {
            if (ModelState.IsValid)
            {

                //return View(Dept);
                try
                {
                    int Dept = _departmentService.AddDepartment(createDepartmentDto);
                    if (Dept > 0)
                    {
                        //return View("Index",_departmentService.GetAllDepts());
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Cannot Be Created !");
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
            return View(createDepartmentDto);

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
            var Dept = _departmentService.GetDeptById(id.Value);
            if (Dept is null) return NotFound();
            return View(Dept);


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
            var Dept = _departmentService.GetDeptById(id.Value);
            if (Dept is null) return NotFound();//404
            var DeptVM = new DepartmentEditViewModel()
            {

                Code = Dept.Code,
                Name = Dept.Name,
                Description = Dept.Description,
                DateOfCreation = Dept.DateOfCreation.HasValue ? Dept.DateOfCreation.Value : default
            };
            return View(DeptVM);

        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, DepartmentEditViewModel updatedDepartmentVM)
        {
            if (ModelState.IsValid)
            {

                //return View(Dept);
                try
                {
                    if (!id.HasValue) return BadRequest();
                    var UpdatedDeptDto = new UpdatedDepartmentDto()
                    {
                        Id = id.Value,
                        Code = updatedDepartmentVM.Code,
                        Name = updatedDepartmentVM.Name,
                        Description = updatedDepartmentVM.Description,
                        DateOfCreation = updatedDepartmentVM.DateOfCreation
                    };
                    int Dept = _departmentService.UpdateDepartment(UpdatedDeptDto);
                    if (Dept > 0)
                    {
                        //return View("Index",_departmentService.GetAllDepts());
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Cannot Be Updated !");
                    }

                }
                catch (Exception ex)
                {
                    //Development
                    if (_Env.IsDevelopment())
                    {
                        _logger.LogError($"Department Cannot Be Updated Because: {ex.Message}");
                    }
                    else
                    {
                        _logger.LogError($"Department Cannot Be Updated Because: {ex}");
                        return View("ErrorView", ex);
                    }
                    //Deployment
                }

            }
            return View(updatedDepartmentVM);

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
                bool IsDeleted = _departmentService.RemoveDepartment(id);
                if (IsDeleted)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Cannot Be Deleted !!");
                }
            }
            catch (Exception ex)
            {
                if (_Env.IsDevelopment())
                {
                    _logger.LogError($"Department Cannot Be Updated Because: {ex.Message}");
                }
                else
                {
                    _logger.LogError($"Department Cannot Be Updated Because: {ex}");
                    return View("ErrorView", ex);
                }
                //Deployment
            }
            return RedirectToAction("Delete", new { id });
        }
        #endregion
    }
}
