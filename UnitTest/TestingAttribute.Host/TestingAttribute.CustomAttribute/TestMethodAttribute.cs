using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingAttribute.Model
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : Attribute
    {
        public TestMethodAttribute()
        {
        }
    }
}
