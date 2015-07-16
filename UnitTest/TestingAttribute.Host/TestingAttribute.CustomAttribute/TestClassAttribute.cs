using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestingAttribute.Model
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClassAttribute : Attribute
    {
        public static bool Exists(Type type)
        {
            foreach (var attribute in type.GetCustomAttributes(true))
            {
                if (attribute is TestClassAttribute)
                {
                    return true;
                }
            }
            return false;
        }
        public TestClassAttribute()
        {
        }
    }
}
