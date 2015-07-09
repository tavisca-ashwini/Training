using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public interface IParser
    {
        double Converts(double amount, string currency);
    }
}
