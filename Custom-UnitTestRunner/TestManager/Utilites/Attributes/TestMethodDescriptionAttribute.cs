using System;

namespace TestManager.Utilites.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestMethodDescriptionAttribute : Attribute
    {
        private readonly string _description;

        public TestMethodDescriptionAttribute(string description)
        {
            _description = description;
        }

        public string Description
        {
            get { return _description; }
        }

    }

}
