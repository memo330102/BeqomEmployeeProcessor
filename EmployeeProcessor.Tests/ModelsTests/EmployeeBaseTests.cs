using EmployeeProcessor.Abstracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeProcessor.Tests.ModelsTests
{
    public class EmployeeBaseTests
    {
        [Theory]
        [InlineData("Mehmet Aksak", "Meh*********")]
        [InlineData("Julia", "Jul**")]
        [InlineData("Aynur", "Ayn**")]
        [InlineData("Ali", "Ali")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void EmployeeBase_MaskedName_Return_MaskedName(string name, string expected)
        {
            var employee = new EmployeeBase { Name = name };

            var maskedName = employee.MaskName();

            maskedName.Should().Be(expected);
        }

        [Fact]
        public void EmployeeBase_Years_Should_Be_Greater_Than_Zero()
        {
            var employee = new EmployeeBase { Years = 0 };

            employee.Years.Should().BeGreaterThan(0);
        }

        [Fact]
        public void EmployeeBase_Salary_Should_Be_Greater_Than_Or_Equal_To_1000()
        {
            var employee = new EmployeeBase { Salary = 700 };

            employee.Salary.Should().BeGreaterThanOrEqualTo(0);
        }
    }
}
