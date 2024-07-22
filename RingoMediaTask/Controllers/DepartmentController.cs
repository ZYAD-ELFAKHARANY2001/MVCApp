using Application.IServices;
using DTOs;
using Jumia.DTOS.ViewResultDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace RingoMediaTask.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ResultView<GetDepartments> department = null;
            Department dept = new Department();

            if (id.HasValue)
            {
                dept = await departmentService.GetOne(id);



                if (departmentService.GetOne(id) == null)
                {
                    return NotFound();
                }
            }

            var subDepartments = await departmentService.GetAllSubDept(id);
            var parentDepartments = await departmentService.GetAllParents(dept);

            DepartmentViewModel model = new DTOs.DepartmentViewModel()
            {
                CurrentDepartment = dept,
                SubDepartments = subDepartments,
                ParentDepartments = parentDepartments
            };

            return View(model);
        }
    }
}
