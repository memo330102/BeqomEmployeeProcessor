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
    public class SeniorTests : IClassFixture<Senior>
    {
        private readonly Employee _senior;
        public SeniorTests(Senior senior)
        {
            _senior = senior;
        }

        [Fact]
        public void Senior_CalculateNewSalary_ReturnNewSalary()
        {
            var newSalary = _senior.CalculateNewSalary(1, 1000);

            newSalary.Should().Be(1100);
        }

        [Theory]
        [InlineData(1, 3000, 3300)]
        [InlineData(2, 4000, 4400)]
        [InlineData(4, 5000, 5500)]
        public void Senior_CalculateNewSalary_ReturnNewSalary_InlineData(int years, decimal salary, decimal expected)
        {
            var newSalary = _senior.CalculateNewSalary(years, salary);

            newSalary.Should().Be(expected);
        }

        [Fact]
        public void Senior_CalculateNewSalary_Should_Be_Greater_Than_Or_Equal_To_Old_Salary()
        {
            var newSalary = _senior.CalculateNewSalary(1, 1000);

            newSalary.Should().BeGreaterThanOrEqualTo(1000);
        }

        [Fact]
        public void Senior_CalculateNewSalary_Should_Be_Positive()
        {
            var newSalary = _senior.CalculateNewSalary(1, 1000);

            newSalary.Should().BePositive();
        }

        [Fact]
        public void Junior_CalculateNewSalary__Return_Exception_If_Years_Less_Than_Or_Equal_To_Zero()
        {
            Action action = () => _senior.CalculateNewSalary(0, 2000);

            action.Should().Throw<ArgumentException>().WithMessage(ErrorMessages.Years_Must_Be_Greater_Than_Zero);
        }

        [Fact]
        public void Junior_CalculateNewSalary__Return_Exception_If_Salary_Less_Than_1000()
        {
            Action action = () => _senior.CalculateNewSalary(4, 500);

            action.Should().Throw<ArgumentException>().WithMessage(ErrorMessages.Salary_Must_Be_Greater_Than_Or_Equal_1000);
        }
    }
}
