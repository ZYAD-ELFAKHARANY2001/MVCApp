using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IDepartment
    {
        IQueryable<Department> GetAllSubDept(int ParentId);
        IQueryable<Department> GetAllSubDept(Department ParentDepartment);
        IQueryable<Department> GetAllParents(Department department);
        IQueryable<Department> GetAllParents(int departmentId);
        


    }
}
