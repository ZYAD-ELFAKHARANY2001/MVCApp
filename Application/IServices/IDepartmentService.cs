using DTOs;
using Jumia.DTOS.ViewResultDtos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IDepartmentService
    {
        Task<ResultDataForPagination<GetDepartments>> GetAll();

        Task<ResultDataForPagination<GetDepartments>> GetAllSubDept(int? ParentId);
        Task<ResultDataForPagination<GetDepartments>> GetAllSubDept(Department ParentDepartment);
        Task<ResultDataForPagination<GetDepartments>> GetAllParents(Department department);
        Task<ResultDataForPagination<GetDepartments>> GetAllParents(int departmentId);
        Task<Department> GetOne(int? id);

    }
}
