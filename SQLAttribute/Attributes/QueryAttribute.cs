using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAttribute.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class QueryAttribute : Attribute
    {
        public System.Data.CommandType CommandType { get; set; }
        public String CommandText { get; set; }
        public bool Transaction { get; set; }
    }

}
