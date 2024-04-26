using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Abstracts
{
    public class EmployeeBase
    {
        public string Name { get; set; }
        public int Years { get; set; }
        public decimal Salary { get; set; }
        public string MaskName()
        {
            if (string.IsNullOrEmpty(Name) || Name.Length <= 3)
                return Name;

            StringBuilder maskedName = new StringBuilder(Name.Length);
            maskedName.Append(Name.Substring(0, 3));
            maskedName.Append('*', Name.Length - 3);

            return maskedName.ToString();
        }
    }
}
