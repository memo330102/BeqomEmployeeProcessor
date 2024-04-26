using EmployeeProcessor.Abstracts;
using EmployeeProcessor.Interfaces;
using EmployeeProcessor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Services
{
    public class Junior : Employee
    {
        public override  decimal CalculateNewSalary(int years, decimal salary)
        {
            if (years <= 0)
            {
                throw new ArgumentException(ErrorMessages.Years_Must_Be_Greater_Than_Zero);
            }
            if (salary < 1000)
            {
                throw new ArgumentException(ErrorMessages.Salary_Must_Be_Greater_Than_Or_Equal_1000);
            }
            try
            {
                decimal newSalary = (salary * 5 / 100) + (salary * years > 5 ? 5 : years) / 100 + salary;

                return newSalary;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
