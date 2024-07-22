using Jumia.DTOS.ViewResultDtos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DepartmentViewModel
    {
        public Department CurrentDepartment { get; set; }
        public ResultDataForPagination<GetDepartments> SubDepartments { get; set; }
        public ResultDataForPagination<GetDepartments> ParentDepartments { get; set; }
    }
}
