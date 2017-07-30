using System;

namespace TestManager.Utilites.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleAttribute : Attribute
    {
        private readonly Modules _module;

        public ModuleAttribute(Modules module)
        {
            _module = module;
        }

        public Modules Module
        {
            get { return _module; }
        }
    }
}