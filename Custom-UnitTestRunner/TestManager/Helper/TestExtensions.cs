using System;
using System.Linq;
using System.Reflection;
using TestManager.Utilites.Attributes;

namespace TestManager.Helper
{
    public static class TestExtensions
    {
        public static string GetTestMethodDescription(this MethodBase method)
        {
            var methodAttrib = method.GetCustomAttributes(typeof(TestMethodDescriptionAttribute), false);
            var description = ((TestMethodDescriptionAttribute)methodAttrib[0]).Description;
            return description;
        }
        public static Modules GetTestModuleName<TType>() where TType: class 
        {
            var classAttribute = typeof(TType).GetCustomAttributes(typeof(ModuleAttribute)).Cast<ModuleAttribute>().FirstOrDefault();
            return classAttribute.Module;
        }

        public static string GetName<TType>(this TType value) where TType : IConvertible
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(ModuleNameAttribute), false);
            var description = ((ModuleNameAttribute)attributes[0]).ModuleName;
            return description;
        }
    }
}