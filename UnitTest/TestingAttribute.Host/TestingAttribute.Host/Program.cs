using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAttribute.Model;
using System.Reflection;
using TestingAttribute;

namespace TestingAttribute.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string category;
                string methodType;
                List<string> methodList=null;

                Console.WriteLine("Enter type of Method to be searched : Test / Ignore");
                methodType = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(methodType) == true)
                    throw new Exception("Invalid Method Type Entered");

                if (string.Equals(methodType, "Test", StringComparison.OrdinalIgnoreCase))
                {
                    methodList = new RetreiveSelectMethods().SelectTestMethods(args[0]);
                    if (methodList.Count == 0)
                    {
                        Console.WriteLine("Test Method is not available");
                    }
                    else
                    {
                        foreach (string method in methodList)
                        {
                            Console.WriteLine(method);
                        }
                    }
                }
                if (string.Equals(methodType, "IgnoreMethod", StringComparison.OrdinalIgnoreCase))
                {
                    methodList = new RetreiveSelectMethods().SelectTestMethods(args[0]);
                    if (methodList.Count == 0)
                    {
                        Console.WriteLine("Test Method is not available");
                    }
                    else
                    {
                        foreach (string method in methodList)
                        {
                            Console.WriteLine(method);
                        }
                    }
                }
                Console.WriteLine("Enter the Test Case category to be searched:");
                category = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(category) == true)
                    throw new Exception("Invalid category entered");

                methodList = new RetreiveSelectMethods().SelectTestMethodCategory(args[0], category);
                if (methodList.Count == 0)
                {
                    Console.WriteLine("There is no Test method belonging to that category.");
                }
                else
                {
                    foreach (string method in methodList)
                    {
                        Console.WriteLine(method);
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
