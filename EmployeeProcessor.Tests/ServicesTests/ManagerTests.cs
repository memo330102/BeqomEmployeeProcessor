using EmployeeProcessor.Abstracts;
using EmployeeProcessor.Services;
using EmployeeProcessor.Service;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeProcessor.Tests.EmployeeTypeTests
{
    public class ManagerTests : IClassFixture<Manager>
    {
        private readonly Employee _manager;
        public ManagerTests(Manager manager)
        {
            _manager = manager;
        }

        [Fact]
        public void Manager_CalculateNewSalary_ReturnNewSalary()
        {
            var newSalary = _manager.CalculateNewSalary(1, 1000);

            newSalary.Should().Be(1150);
        }

        [Theory]
        [InlineData(1, 4000, 4600)]
        [InlineData(2, 5000, 5750)]
        [InlineData(4, 6000, 6900)]
        public void Manager_CalculateNewSalary_ReturnNewSalary_InlineData(int years, decimal salary, decimal expected)
        {
            var newSalary = _manager.CalculateNewSalary(years, salary);

            newSalary.Should().Be(expected);
        }

        [Fact]
        public void Manager_CalculateNewSalary_Should_Be_Greater_Than_Or_Equal_To_Old_Salary()
        {
            var newSalary = _manager.CalculateNewSalary(1, 1000);

            newSalary.Should().BeGreaterThanOrEqualTo(1000);
        }

        [Fact]
        public void Manager_CalculateNewSalary_Should_Be_Positive()
        {
            var newSalary = _manager.CalculateNewSalary(1, 1000);

            newSalary.Should().BePositive();
        }

        [Fact]
        public void Junior_CalculateNewSalary__Return_Exception_If_Years_Less_Than_Or_Equal_To_Zero()
        {
            Action action = () => _manager.CalculateNewSalary(0, 1000);

            action.Should().Throw<ArgumentException>().WithMessage(ErrorMessages.Years_Must_Be_Greater_Than_Zero);
        }

        [Fact]
        public void Junior_CalculateNewSalary__Return_Exception_If_Salary_Less_Than_1000()
        {
            Action action = () => _manager.CalculateNewSalary(3, 700);

            action.Should().Throw<ArgumentException>().WithMessage(ErrorMessages.Salary_Must_Be_Greater_Than_Or_Equal_1000);
        }
    }
}
