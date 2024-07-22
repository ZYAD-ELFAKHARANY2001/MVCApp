using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class GetDepartments
    {
        public int? id {  get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int? ParentDepartmentId { get; set; }
        public string ParentDepartmentName { get; set; }
       
        public GetDepartments(Department department)
        {
            this.Name = department.Name;
            this.Logo = department.Logo;
            ParentDepartmentId = department.ParentDepartmentId;
            ParentDepartmentName = department.ParentDepartment.Name;
            
        }

        public GetDepartments()
        {
        }
    }
}
