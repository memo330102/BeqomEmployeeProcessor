using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Abstracts
{
    public abstract class Employee : EmployeeBase
    {
        public abstract decimal CalculateNewSalary(int years, decimal salary);
    }
}
