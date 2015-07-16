using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAttribute.Model
{
    [TestClassAttribute()]
    public class ClassOne
    {
        [TestMethodAttribute()]
        public void Addition()
        {
        }
        [IgnoreMethodAttribute()]
        public void Multiply()
        {
        }
        [TestMethodAttribute()]
        public void Square()
        {
        }
        public void CubicNumber()
        {
        }
    }
}
