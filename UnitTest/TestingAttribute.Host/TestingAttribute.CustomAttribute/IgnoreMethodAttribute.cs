using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestingAttribute.Model
{
    [AttributeUsage(AttributeTargets.Method)]
    public class IgnoreMethodAttribute : System.Attribute
    {
        
    }
}
