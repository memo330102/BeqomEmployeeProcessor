using EmployeeProcessor;
using EmployeeProcessor.Abstracts;
using EmployeeProcessor.Services;
using EmployeeProcessor.Interfaces;
using EmployeeProcessor.Service;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeProcessor.Tests
{
    public class ReporterTests : IClassFixture<Reporter>
    {
        private readonly Reporter _reporter;
        public ReporterTests(Reporter reporter)
        {
            _reporter = reporter;
        }

        [Fact]
        public void Reporter_GenerateReport_Return_All_Employee_Report()
        {
            var employeeList = new List<Employee>
            {
                new Trainee { Name = "Mehmet", Years = 1, Salary = 1000 },
                new Junior { Name = "Ricardo", Years = 2, Salary = 2000 },
                new Senior { Name = "Dorota", Years = 3, Salary = 3000 },
                new Manager { Name = "Piotr", Years = 4, Salary = 4000 }
            };

            var report = _reporter.GenerateReport(employeeList);

            report.Should().Contain("Trainee").And.Contain("Junior").And.Contain("Senior").And.Contain("Manager");
        }

        [Fact]
        public void Reporter_GenerateEmployeeReport_Return_Report_For_Trainee()
        {
            Employee employeeT = new Trainee { Name = "Ahmet", Years = 1, Salary = 1000 };

            var report = _reporter.GenerateEmployeeReport(employeeT);

            report.Should().Contain("Ahm", Exactly.Once()).And.Contain("Trainee", Exactly.Once()).And.Contain("1").And.Contain("1000", Exactly.Once()).And.Contain("1010", Exactly.Once());
        }

        [Fact]
        public void Reporter_GenerateEmployeeReport_Return_Report_For_Junior()
        {
            Employee employeeJ = new Junior { Name = "Julia", Years = 2, Salary = 2000 };

            var report = _reporter.GenerateEmployeeReport(employeeJ);

            report.Should().Contain("Jul", Exactly.Once()).And.Contain("Junior", Exactly.Once()).And.Contain("2").And.Contain("2000", Exactly.Once()).And.Contain("2100", Exactly.Once());
        }

        [Fact]
        public void Reporter_GenerateEmployeeReport_Return_Report_For_Senior()
        {
            Employee employeeS = new Senior { Name = "Dorota", Years = 3, Salary = 3000 };

            var report = _reporter.GenerateEmployeeReport(employeeS);

            report.Should().Contain("Dor", Exactly.Once()).And.Contain("Senior", Exactly.Once()).And.Contain("3").And.Contain("3000", Exactly.Once()).And.Contain("3300", Exactly.Once());
        }

        [Fact]
        public void Reporter_GenerateEmployeeReport_Return_For_Manager()
        {
            Employee employeeM = new Manager { Name = "Cahit", Years = 4, Salary = 4000 };

            var report = _reporter.GenerateEmployeeReport(employeeM);

            report.Should().Contain("Cah", Exactly.Once()).And.Contain("Manager", Exactly.Once()).And.Contain("4").And.Contain("4000", Exactly.Once()).And.Contain("4600", Exactly.Once());
        }

        [Fact]
        public void Reporter_GenerateReport_Return_Empty_EmployeeList_Report()
        {
            var employeeList = new List<Employee>();

            var report = _reporter.GenerateReport(employeeList);

            report.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Reporter_GenerateEmployeeReport_Return_Exception_If_Years_Less_Than_Or_Equal_To_Zero()
        {
            Employee employeeT = new Trainee { Name = "John", Years = 0, Salary = 1000 };

            Action action = () => _reporter.GenerateEmployeeReport(employeeT);

            action.Should().Throw<Exception>().WithMessage(ErrorMessages.Years_Must_Be_Greater_Than_Zero);
        }

        [Fact]
        public void Reporter_GenerateEmployeeReport_Return_Exception_If_Salary_Less_Than_1000()
        {
            Employee employeeT = new Trainee { Name = "John", Years = 2, Salary = 789 };

            Action action = () => _reporter.GenerateEmployeeReport(employeeT);

            action.Should().Throw<Exception>().WithMessage(ErrorMessages.Salary_Must_Be_Greater_Than_Or_Equal_1000);
        }
    }
}
