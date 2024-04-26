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
    public class JuniorTests : IClassFixture<Junior>
    {
        private readonly Employee _junior;
        public JuniorTests(Junior junior)
        {
            _junior = junior;
        }

        [Fact]
        public void Junior_CalculateNewSalary_ReturnNewSalary()
        {
            var newSalary = _junior.CalculateNewSalary(1, 1000);

            newSalary.Should().Be(1050);
        }

        [Theory]
        [InlineData(1, 2000, 2100)]
        [InlineData(3, 3000, 3150)]
        [InlineData(2, 4000, 4200)]
        public void Junior_CalculateNewSalary_ReturnNewSalary_InlineData(int years, decimal salary, decimal expected)
        {
            var newSalary = _junior.CalculateNewSalary(years, salary);

            newSalary.Should().Be(expected);
        }

        [Fact]
        public void Junior_CalculateNewSalary_Should_Be_Greater_Than_Or_Equal_To_Old_Salary()
        {
            var newSalary = _junior.CalculateNewSalary(1, 1000);

            newSalary.Should().BeGreaterThanOrEqualTo(1000);
        }

        [Fact]
        public void Junior_CalculateNewSalary_Should_Be_Positive()
        {
            var newSalary = _junior.CalculateNewSalary(1, 1000);

            newSalary.Should().BePositive();
        }

        [Fact]
        public void Junior_CalculateNewSalary__Return_Exception_If_Years_Less_Than_Or_Equal_To_Zero()
        {
            Action action = () => _junior.CalculateNewSalary(0, 1500);

            action.Should().Throw<ArgumentException>().WithMessage(ErrorMessages.Years_Must_Be_Greater_Than_Zero);
        }

        [Fact]
        public void Junior_CalculateNewSalary__Return_Exception_If_Salary_Less_Than_1000()
        {
            Action action = () => _junior.CalculateNewSalary(3, 700);

            action.Should().Throw<ArgumentException>().WithMessage(ErrorMessages.Salary_Must_Be_Greater_Than_Or_Equal_1000);
        }
    }
}
