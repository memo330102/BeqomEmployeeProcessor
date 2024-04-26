using EmployeeProcessor.Service;
using EmployeeProcessor.Service.Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeProcessor.Tests
{
    public class OptionTests
    {
        private Option<SomeClass> defaultOption;

        [Fact]
        public void Empty_Option_Has_No_Value()
        {
            Assert.False(Option<SomeClass>.Empty().HasValue);
        }

        [Fact]
        public void Default_Option_IsEmpty()
        {
            Assert.Equal(Option<SomeClass>.Empty().Value, defaultOption?.Value);
        }

        [Fact]
        public void Non_Empty_Option_Has_Value()
        {
            Assert.True(Option<SomeClass>.FromValue(new SomeClass()).HasValue);
        }

        [Fact]
        public void Empty_Option_Value_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => Option<SomeClass>.Empty().Value);
        }

        [Fact]
        public void Non_Empty_Option_Returns_Its_Value()
        {
            var value = new SomeClass();
            Assert.Same(value, Option<SomeClass>.FromValue(value).Value);
        }

        [Fact]
        public void Comparison_Is_Correct_If_Not_Empty()
        {
            var someClass = new SomeClass();
            Assert.True(Option<SomeClass>.FromValue(someClass).Value == Option<SomeClass>.FromValue(someClass).Value);
            Assert.False(Option<SomeClass>.FromValue(someClass) == Option<SomeClass>.Empty());
        }

        [Fact]
        public void Empty_Option_ValueOr_Evaluates_Else_Branch()
        {
            var expected = new SomeClass();
            Assert.Same(expected, Option<SomeClass>.Empty().ValueOr(() => expected));
        }
    }
}

