using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
   internal interface DepartmentRepository
    {
        IEnumerable<Departments> GetAllDepartments();
        public void AddDepartment(string newDep);
    }
}
