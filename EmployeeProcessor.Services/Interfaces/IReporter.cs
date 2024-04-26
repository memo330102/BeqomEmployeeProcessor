using EmployeeProcessor.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Interfaces
{
    public interface IReporter
    {
        public string GenerateReport(List<Employee> employees);
        public string GenerateEmployeeReport(Employee employee);

    }
}
