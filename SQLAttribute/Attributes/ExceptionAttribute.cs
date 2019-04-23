using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAttribute.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExceptionAttribute : LoggingAttribute
    {
        public Type ExceptionClass { get; set; }

    }
}
