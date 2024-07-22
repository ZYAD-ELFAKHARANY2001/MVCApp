using Application.Contract;
using Application.IServices;
using DTOs;
using Jumia.DTOS.ViewResultDtos;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DepartmentServices : IDepartmentService
    {
        private readonly IBaseRepository<Department,int> baseRepository;
        public DepartmentServices(Contract.IBaseRepository<Department,int> baseRepository)
        {

            this.baseRepository = baseRepository;

        }
        public async Task<ResultDataForPagination<GetDepartments>> GetAll()
        {
            var departments = await baseRepository.GoTo.Select(d => new GetDepartments(d)).ToListAsync();
            ResultDataForPagination<GetDepartments> resultDataList = new ResultDataForPagination<GetDepartments>();
            resultDataList.Entities = departments;
            resultDataList.count = departments.Count();
            return resultDataList;
        }

        public async Task<ResultDataForPagination<GetDepartments>> GetAllParents(Department department)
        {
            var parents = new List<GetDepartments>();
            var current = department;
            GetDepartments c = new();
            while (current?.ParentDepartmentId != null)
            {
                if (current != null)
                {
                    parents.Add(c);
                }
                current = await baseRepository.GoTo
                    .FirstOrDefaultAsync(d => d.Id == current.ParentDepartmentId);
                c = new GetDepartments(current);

               
            }
            parents.Reverse(); 

            //List<GetDepartments> departments = new List<GetDepartments>();

            //while (baseRepository.GoTo.Any(d=> d.ParentDepartmentId!=null))
            //{
            //    departments.AddRange((IEnumerable<GetDepartments>)baseRepository.GoTo.Select(d => new GetDepartments(d)).ToListAsync());
            //    //departments.ToListAsync();
            //        //baseRepository.GoTo.Select(d => new GetDepartments(d)).ToListAsync();

            //}
            ResultDataForPagination<GetDepartments> resultDataList = new ResultDataForPagination<GetDepartments>();
            resultDataList.Entities = parents;
            resultDataList.count = parents.Count();
            return resultDataList;
        }
        public async Task<Department> GetOne(int? id)
        {
            var department = await baseRepository.GoTo.FirstOrDefaultAsync(d => d.Id == id);
            GetDepartments departments = new GetDepartments();
            if (department == null)
            {
                return null;
            }
            else
            {
                departments = new GetDepartments(department);
                return department;
            }
        }

        public Task<ResultDataForPagination<GetDepartments>> GetAllParents(int departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDataForPagination<GetDepartments>> GetAllSubDept(int? ParentId)
        {
            var x = await baseRepository.GoTo
                        .Where(d => d.ParentDepartmentId == ParentId)
                        .Select(d => new GetDepartments(d))
                        .ToListAsync();
            ResultDataForPagination<GetDepartments> resultDataList = new ResultDataForPagination<GetDepartments>();
            resultDataList.Entities = x;
            resultDataList.count = x.Count();
            return resultDataList;
        }

        public Task<ResultDataForPagination<GetDepartments>> GetAllSubDept(Department ParentDepartment)
        {
            throw new NotImplementedException();
        }
    }
}
