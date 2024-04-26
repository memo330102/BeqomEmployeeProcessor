using EmployeeProcessor.Abstracts;
using EmployeeProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Services
{
    public class Reporter : IReporter
    {
        public string GenerateReport(List<Employee> employees)
        {
            var reportBuilder = new StringBuilder();
            try
            {
                foreach (var employee in employees)
                {
                    reportBuilder.AppendLine(GenerateEmployeeReport(employee));
                }
                return reportBuilder.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GenerateEmployeeReport(Employee employee)
        {
            try
            {
                var newSalary = employee.CalculateNewSalary(employee.Years, employee.Salary);
                return string.Format("Employee Name: {0}, Type: {1}, Years: {2}, Salary: {3}, New Salary: {4}",
                                     employee.MaskName(), employee.GetType().Name, employee.Years, employee.Salary, newSalary);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
