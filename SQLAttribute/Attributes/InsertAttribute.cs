using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAttribute.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class InsertAttribute : Attribute
    {
        public bool Transaction { get; set; }
        public String Table { get; set; }
    }

}
