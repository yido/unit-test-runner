using System;
using System.Collections.Generic;
using System.Linq;
using TestManager.Helper;
using TestManager.Utilites.Attributes;

namespace TestManager.Services
{
    public abstract class TestRegistration
    {
        private readonly Dictionary<Modules, Dictionary<Type, TestSkeleton>> _registeredBinding;
        private Dictionary<Modules, Type> _prioritizedTests;

        protected TestRegistration()
        {
            _registeredBinding =
                new Dictionary<Modules, Dictionary<Type,TestSkeleton>>();
        }
        public abstract void Registration();

        public TestSkeleton Register<TTest>() where TTest : class
        {
            var module = TestExtensions.GetTestModuleName<TTest>();
            var testSkeleton = (new TestSkeleton()).Module(module);

            _registeredBinding.Add(module,
                new Dictionary<Type,TestSkeleton> { { typeof (TTest), testSkeleton } });

            return testSkeleton;
        }

        public void Prioritize()
        {
            _prioritizedTests = new Dictionary<Modules, Type>();

            var registeredTests =
                _registeredBinding.
                    OrderByDescending(v => v.Value.Values.Select(tsk => tsk.GetPriority));
            foreach (var registeredTest in registeredTests)
            {
                _prioritizedTests.Add(registeredTest.Key, (registeredTest.Value.Keys.FirstOrDefault()));
            }

        }

        public Dictionary<Modules, Dictionary<Type,TestSkeleton>> RigisteredBinding
        {
            get
            {
                return _registeredBinding ?? new Dictionary<Modules, Dictionary<Type,TestSkeleton>>();
            }
        }

        public IEnumerable<Type> PrioritizedTests
        {
            get { return _prioritizedTests.Select(t =>t.Value); }
        }
    }
}
