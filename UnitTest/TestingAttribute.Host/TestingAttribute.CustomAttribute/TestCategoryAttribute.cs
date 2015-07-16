using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestingAttribute.Model
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestCategoryAttribute : Attribute
    {
        private string _category;
        
        public TestCategoryAttribute(string category)
        {
            this._category = category;
        }
        public string Category { get { return _category; }}
    }
}
