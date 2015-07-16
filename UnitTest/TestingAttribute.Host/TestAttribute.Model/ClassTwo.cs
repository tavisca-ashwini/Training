using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAttribute.Model;

namespace TestingAttribute.Model
{
    [TestClassAttribute()]
    public class ClassTwo 
    {
        [TestMethodAttribute()]
        public void Method1 ()
        {
            Console.WriteLine("In method 1");
        }

        [TestMethodAttribute()]
        [TestCategoryAttribute("smoke test")]
        public void Method2 ()
        {
            Console.WriteLine("In method 2 : category type attribute");
        }
    }
}
