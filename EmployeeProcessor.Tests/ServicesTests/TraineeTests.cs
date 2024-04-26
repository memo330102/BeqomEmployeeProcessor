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
    public class TraineeTests : IClassFixture<Trainee>
    {
        private readonly Employee _trainee;
        public TraineeTests(Trainee trainee)
        {
            _trainee = trainee;
        }

        [Fact]
        public void Trainee_CalculateNewSalary_ReturnNewSalary()
        {
            var newSalary = _trainee.CalculateNewSalary(1, 1000);

            newSalary.Should().Be(1010);
        }

        [Theory]
        [InlineData(1, 1000, 1010)]
        [InlineData(4, 2000, 2020)]
        [InlineData(3, 3000, 3030)]
        public void Trainee_CalculateNewSalary_ReturnNewSalary_InlineData(int years, decimal salary, decimal expected)
        {
            var newSalary = _trainee.CalculateNewSalary(years, salary);

            newSalary.Should().Be(expected);
        }

        [Fact]
        public void Trainee_CalculateNewSalary_Should_Be_Greater_Than_Or_Equal_To_Old_Salary()
        {
            var newSalary = _trainee.CalculateNewSalary(1, 1000);

            newSalary.Should().BeGreaterThanOrEqualTo(1000);
        }

        [Fact]
        public void Trainee_CalculateNewSalary_Should_Be_Positive()
        {
            var newSalary = _trainee.CalculateNewSalary(1, 1000);

            newSalary.Should().BePositive();
        }

        [Fact]
        public void Junior_CalculateNewSalary__Return_Exception_If_Years_Less_Than_Or_Equal_To_Zero()
        {
            Action action = () => _trainee.CalculateNewSalary(0, 3000);

            action.Should().Throw<ArgumentException>().WithMessage(ErrorMessages.Years_Must_Be_Greater_Than_Zero);
        }

        [Fact]
        public void Junior_CalculateNewSalary__Return_Exception_If_Salary_Less_Than_1000()
        {
            Action action = () => _trainee.CalculateNewSalary(2, 900);

            action.Should().Throw<ArgumentException>().WithMessage(ErrorMessages.Salary_Must_Be_Greater_Than_Or_Equal_1000);
        }
    }
}
