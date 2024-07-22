using Application.Contract;
using Context;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DepartmentRepository : BaseRepository<Department, int>, IDepartment
    {
        protected ApplicationContext _applicationContext;
        public DepartmentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IQueryable<Department> GetAllParents(Department department)
        {
           throw new NotImplementedException();

        }

        public IQueryable<Department> GetAllParents(int departmentId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> GetAllSubDept(int ParentId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> GetAllSubDept(Department ParentDepartment)
        {
            throw new NotImplementedException();
        }
    }
}
