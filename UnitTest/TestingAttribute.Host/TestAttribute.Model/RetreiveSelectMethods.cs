using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestingAttribute.Model;

namespace TestingAttribute
{
   public class RetreiveSelectMethods
   {
       public List<string> SelectTestMethods(string dllPath)
       {
           List<string> methodList = new List<string>();
           try
           {
               Assembly assembly = Assembly.LoadFrom(dllPath);
               foreach (Type type in assembly.GetTypes())
               {
                   if (TestClassAttribute.Exists(type))
                   {
                       foreach (var attributes in type.GetCustomAttributes(false))
                       {
                           TestClassAttribute testClassAttribute = attributes as TestClassAttribute;
                           if (null != testClassAttribute)
                           {
                               foreach (MethodInfo method in type.GetMethods())
                               {
                                   foreach (Attribute customAttribute in method.GetCustomAttributes(false))
                                   {
                                       TestMethodAttribute testMethodAttribute = customAttribute as TestMethodAttribute;
                                       if (null != testMethodAttribute)
                                       {
                                           methodList.Add(method.Name);
                                       }
                                   }
                               }
                           }
                       }
                   }
               }
           }
           catch (Exception e)
           {
               throw new System.Exception(e.Message,e);
           }
               return methodList;
       }

       public List<string> SelectTestMethodCategory(string dllPath,string category)
       {
           List<string> methodList = new List<string>();
           try
           {
               Assembly assembly = Assembly.LoadFrom(dllPath);
               foreach (Type type in assembly.GetTypes())
               {
                   if (TestClassAttribute.Exists(type))
                   {
                       foreach (var attributes in type.GetCustomAttributes(false))
                       {
                           TestClassAttribute testClassAttribute = attributes as TestClassAttribute;
                           if (null != testClassAttribute)
                           {
                               foreach (MethodInfo methodInfo in type.GetMethods())
                               {
                                   foreach (Attribute customAttribute in methodInfo.GetCustomAttributes(false))
                                   {
                                       TestCategoryAttribute testCategoryAttribute = customAttribute as TestCategoryAttribute;
                                       if (null != testCategoryAttribute)
                                       {
                                           if (string.Equals(testCategoryAttribute.Category,category,StringComparison.OrdinalIgnoreCase))
                                           methodList.Add(methodInfo.Name);
                                       }
                                   }
                               }
                           }
                       }
                   }

               }
           }
           catch (Exception e)
           {
               throw new System.Exception(e.Message, e);
           }
           return methodList;
       }
   }
}