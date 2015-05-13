using System;

namespace TestManager.Utilites.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ModuleNameAttribute : Attribute
    {
        private readonly string _moduleName;
        private readonly Type _type;

        public ModuleNameAttribute(string module, Type type)
        {
            _moduleName = module;
            _type = type;
        }
        public string ModuleName
        {
            get { return _moduleName; }
        }
    }
}