using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Service
{
    public class Option<T>
    {
        private T value;
        private Option() { }
        public static Option<T> Empty()
        {
            return new Option<T>();
        }
        public static Option<T> Some(T value)
        {
            return new Option<T> { value = value };
        }
        public bool HasValue
        {
            get { return !EqualityComparer<T>.Default.Equals(value, default(T)); }
        }
        public T Value
        {
            get
            {
                if (HasValue)
                    return value;
                else
                    throw new InvalidOperationException("Option does not have a value.");
            }
        }
        public static Option<T> FromValue(T value)
        {
            if (value == null)
                return Empty();
            else
                return Some(value);
        }
        public T ValueOr(Func<T> alternative)
        {
            if (HasValue)
                return value;
            else
                return alternative();
        }
    }
}
